using System;
using SQLite;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace GymApp.Models
{
    public class OneRepMaxRepository
    {
        SQLiteAsyncConnection conn;

        public OneRepMaxRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<OneRepMax>().Wait();
        }
        public async Task AddNewORMAsync(string exercise, double oneRep, double weight, int reps)
        {
            await conn.InsertAsync(new OneRepMax { ExerciseName = exercise, OneRep = oneRep, Reps = reps, Weight = weight });
        }

        public async Task EditORMAsync(OneRepMax oneToEdit)
        {
            await conn.UpdateAsync(oneToEdit);
        }

        public async Task RemoveORMAsync(OneRepMax oneToDelete)
        {
            await conn.DeleteAsync(oneToDelete);
        }

        public async Task<List<OneRepMax>> GetOneRepMaxesAsync()
        {
            return await conn.Table<OneRepMax>().ToListAsync();
        }
    }
}
