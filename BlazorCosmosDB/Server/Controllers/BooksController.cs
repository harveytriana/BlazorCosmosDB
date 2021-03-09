// ******************************
// Article BlazorSpread
// ******************************
using BlazorCosmosDB.Server.Services;
using BlazorCosmosDB.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCosmosDB.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly ICosmosService<Book> _cosmos;

        public BooksController(ICosmosService<Book> cosmosDbService)
        {
            _cosmos = cosmosDbService;
        }

        // GET: api/<Books>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _cosmos.GetItemsAsync("SELECT * FROM c");
        }

        // GET api/<Books>/ISBN/Partition
        [HttpGet("{id}/{partition}")]
        public async Task<Book> Get(string id, string partition = Utils.DEFAULT_PARTITION)
        {
            return await _cosmos.GetItemAsync(id, partition);
        }

        // POST api/<Books>
        [HttpPost]
        public async Task<bool> Post([FromBody] Book item)
        {
            return await _cosmos.AddItemAsync(item);
        }

        // PUT api/<Books>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(string id, [FromBody] Book item)
        {
            return await _cosmos.UpdateItemAsync(id, item);
        }

        // DELETE api/<Books>/id/partition
        [HttpDelete("{id}")]
        [HttpDelete("{id}/{partition}")]
        public async Task<bool> Delete(string id, string partition = Utils.DEFAULT_PARTITION)
        {
            return await _cosmos.DeleteItemAsync(id, partition);
        }

        // Custom method
        [HttpGet("SeedData")]
        public async Task<IEnumerable<Book>> GetSeedData()
        {
            return await SeedData.GetDataSample(_cosmos);
        }

    }
}
