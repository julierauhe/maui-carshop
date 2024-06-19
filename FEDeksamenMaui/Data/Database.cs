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
        //private readonly SQLiteAsyncConnection _connection;
        //public DataBase()
        //{
        //    var dataDir = FileSystem.AppDataDirectory;
        //    var databasePath = Path.Combine(dataDir, "INSERTNAME.db");

        //    var dbOptions = new SQLiteConnectionString(databasePath, true);
        //    _connection = new SQLiteAsyncConnection(dbOptions);

        //    _ = Initialise();
        //}

        //private async Task Initialise()
        //{
        //    //_ = _connection.DropTableAsync<DebtorItems>();
        //    //_ = _connection.DropTableAsync<PartialDebt>();

        //    _ = _connection.CreateTableAsync<PartialDebt>();
        //    _ = _connection.CreateTableAsync<DebtorItems>();

        //    await Task.CompletedTask;
        //}


        //public async Task<int> SaveNewDebtor(DebtorItems item)
        //{
        //    await _connection.InsertAsync(item);
        //    return item.Id;
        //}

        //public async Task<int> SaveNewPartialDebt(PartialDebt item)
        //{
        //    return await _connection.InsertAsync(item);
        //}

        //public async Task<DebtorItems> GetDebtor(int id)
        //{
        //    return await _connection.Table<DebtorItems>().Where(d => d.Id == id).FirstOrDefaultAsync();
        //}

        //public async Task<List<DebtorItems>> GetAllDebtors()
        //{
        //    return await _connection.Table<DebtorItems>().ToListAsync();
        //}

        //public async Task<List<PartialDebt>> GetAllPartialDebtsById(int id)
        //{
        //    return await _connection.Table<PartialDebt>().Where(p => p.DebitorId == id).ToListAsync();
        //}
    }
}
