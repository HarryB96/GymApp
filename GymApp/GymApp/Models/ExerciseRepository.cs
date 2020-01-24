using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace GymApp.Models
{
    public class ExerciseRepository
    {
        SQLiteAsyncConnection conn;
        static HttpClient client = new HttpClient();

        public ExerciseRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Exercise>().Wait();
        }
        public async Task EditExerciseAsync(Exercise oneToEdit)
        {
            await conn.UpdateAsync(oneToEdit);
        }
        public async Task<List<Exercise>> GetProgramAsync()
        {
            
            if (conn.Table<Exercise>().CountAsync().Result == 0)
            {
                await PopulateProgramAsync();
                return await conn.Table<Exercise>().ToListAsync();
            }
            else
            {
                return await conn.Table<Exercise>().ToListAsync();
            }
            
        }
        //Getting List of exercises whch make up the program
        async Task PopulateProgramAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3.raw"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var text = await client.GetStringAsync("https://api.github.com/repos/HarryB96/Data/contents/ProgramContent.json");
            List<Exercise> Program = JsonConvert.DeserializeObject<List<Exercise>>(text);
            Program.ForEach(e => conn.InsertAsync(e));
        }
    }
}
