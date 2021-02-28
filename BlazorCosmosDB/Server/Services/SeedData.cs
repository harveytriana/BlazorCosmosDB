// ******************************
// Article BlazorSpread
// ******************************
using BlazorCosmosDB.Shared;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorCosmosDB.Server.Services
{
    public static class SeedData
    {
        public static async Task<List<Book>> GetBooksData(ICosmosService<Book> _service)
        {
            var file = $"{Startup.PATH}/Statics/Book_SEED.json";
            if (File.Exists(file)) {
                var data = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(file));
                foreach (Book item in data) {
                    await _service.AddItemAsync(item);
                }
                return data;
            }
            return new List<Book>();
        }
    }
}
