using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Mobil.Models;

namespace Mobil.Data
{
    public class GymListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public GymListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AbonamenteList>().Wait();
            _database.CreateTableAsync<Antrenori>().Wait();
            _database.CreateTableAsync<Cursuri>().Wait();
        }
        public Task<List<AbonamenteList>> GetGymListsAsync()
        {
            return _database.Table<AbonamenteList>().ToListAsync();
        }
        public Task<AbonamenteList> GetGymListAsync(int id)
        {
            return _database.Table<AbonamenteList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveGymListAsync(AbonamenteList rlist)
        {
            if (rlist.ID != 0)
            {
                return _database.UpdateAsync(rlist);
            }
            else
            {
                return _database.InsertAsync(rlist);
            }
        }
        public Task<int> DeleteGymListAsync(AbonamenteList rlist)
        {
            return _database.DeleteAsync(rlist);
        }

        public Task<int> SaveGymAsync(Antrenori ant)
        {
            if (ant.ID != 0)
            {
                return _database.UpdateAsync(ant);
            }
            else
            {
                return _database.InsertAsync(ant);
            }
        }
        public Task<int> DeleteGymAsync(Antrenori Gym)
        {
            return _database.DeleteAsync(Gym);
        }
        public Task<List<Antrenori>> GetGymsAsync()
        {
            return _database.Table<Antrenori>().ToListAsync();
        }

        public Task<int> SaveListGymAsync(Cursuri listm)
        {
            if (listm.ID != 0)
            {
                return _database.UpdateAsync(listm);
            }
            else
            {
                return _database.InsertAsync(listm);
            }
        }
        public Task<List<Antrenori>> GetListCursuriAsync(int gymListId, Task<List<Antrenori>> antrenori)
        {
            //return _database.QueryAsync<Antrenori>();
            Task<List<Antrenori>> Antrenori;
            return antrenori;
        }
    }
}

