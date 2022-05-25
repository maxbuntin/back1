using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Entities
{
    public class CarsService
    {
        private readonly IMongoCollection<Cars> _cars;

        public CarsService(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _cars = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Cars>("Cars");
        }

        public async Task<List<Cars>> Get()
        {
            return await _cars.Find(_ => true).ToListAsync();
        }
        public async Task<Cars> Get(string id)
        {
            return await _cars.Find(m => m.Id == id).FirstOrDefaultAsync();
        }
        public async Task Create(Cars newCars)
        {
            await _cars.InsertOneAsync(newCars);
        }
        public async Task Update(string id, Cars updateCars)
        {
            await _cars.ReplaceOneAsync(m => m.Id == id, updateCars);
        }
        public async Task Remove(string id)
        {
            await _cars.DeleteOneAsync(m => m.Id == id);
        }
    }
}
