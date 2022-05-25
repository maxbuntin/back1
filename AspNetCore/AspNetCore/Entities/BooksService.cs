using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Entities
{
    public class BooksService
    {
        private readonly IMongoCollection<Books> books;

        public BooksService(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            books = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Books>("Book");
        }

        public async Task<List<Books>> Get()
        {
            return await books.Find(_ => true).ToListAsync();
        }
        public async Task<Books> Get(string id)
        {
            return await books.Find(m => m.Id == id).FirstOrDefaultAsync();
        }
        public async Task Create(Books newBook)
        {
            await books.InsertOneAsync(newBook);
        }
        public async Task Update(string id, Books updateBook)
        {
            await books.ReplaceOneAsync(m => m.Id == id, updateBook);
        }
        public async Task Remove(string id)
        {
            await books.DeleteOneAsync(m => m.Id == id);
        }
    }
}
