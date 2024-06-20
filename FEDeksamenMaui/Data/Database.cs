using FEDeksamenMaui.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEDeksamenMaui.Data
{
    public class Database : IDatabase
    {
        private readonly SQLiteAsyncConnection _connection;
        public Database()
        {
            var dataDir = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(dataDir, "CarWorkshop.db");

            var dbOptions = new SQLiteConnectionString(databasePath, true);
            _connection = new SQLiteAsyncConnection(dbOptions);

            _ = Initialise();
        }

        private async Task Initialise()
        {
            //_ = _connection.DropTableAsync<Order>();
            //_ = _connection.DropTableAsync<Invoice>();

            _ = _connection.CreateTableAsync<Order>();
            _ = _connection.CreateTableAsync<Invoice>();

            await Task.CompletedTask;
        }

        public async Task<int> SaveNewOrder(Order item)
        {
            return await _connection.InsertAsync(item);
        }

        public async Task<int> SaveNewInvoice(Invoice item)
        {
            return await _connection.InsertAsync(item);
        }

        public async Task<List<Order>> GetOrdersForSelectedDate(DateOnly date)
        {
            var dateTimeStart = date.ToDateTime(TimeOnly.MinValue);
            var dateTimeEnd = date.ToDateTime(TimeOnly.MaxValue);

            return await _connection.Table<Order>()
                                    .Where(o => o.TimeOfSubmission >= dateTimeStart && o.TimeOfSubmission <= dateTimeEnd)
                                    .ToListAsync();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _connection.Table<Order>().ToListAsync();
        }
    }
}
