using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Entities
{
    public class UsersService
    {
        private readonly IMongoCollection<User> _user;

        public UsersService(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _user = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<User>("Users");
        }

        public async Task<List<User>> Get()
        {
          return  await _user.Find(_ => true).ToListAsync();
        }
        public async Task<User> Get(string id)
        {
          return  await _user.Find(m => m.Id == id).FirstOrDefaultAsync();
        }
        public async Task Create(User newBooks)
        {
            await _user.InsertOneAsync(newBooks);

        }
        public async Task Update(string id, User updateBooks)
        {
            await _user.ReplaceOneAsync(m => m.Id == id, updateBooks);
        }
        public async Task Remove(string id)
        {
            await _user.DeleteOneAsync(m => m.Id == id);
        }
     }
}
