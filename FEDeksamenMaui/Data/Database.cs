﻿using FEDeksamenMaui.Models;
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
            //_ = _connection.DropTableAsync<Material>();
            //_ = _connection.DropTableAsync<Invoice>();

            _ = _connection.CreateTableAsync<Order>();
            _ = _connection.CreateTableAsync<Material>();
            _ = _connection.CreateTableAsync<Invoice>();

            await Task.CompletedTask;
        }


        public async Task<int> AddMaterials(List<Material> items)
        {
            return await _connection.InsertAllAsync(items);
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
            return await _connection.Table<Order>()
                                    .Where(o => o.TimeOfSubmission.Date == date.ToDateTime(new TimeOnly()).Date)
                                    .ToListAsync();
        }
    }
}
