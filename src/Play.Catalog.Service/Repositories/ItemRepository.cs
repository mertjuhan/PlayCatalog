using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Model;

namespace Play.Catalog.Service.Repositories
{
    public class ItemRepository
    {
        private const string collectionName = "Items";
        private readonly IMongoDatabase _database = null;
        private readonly IMongoCollection<Item> dbcollection;

        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public ItemRepository(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
                dbcollection = _database.GetCollection<Item>(collectionName);
            }

        }

        public async Task<IReadOnlyCollection<Item>> GetItems()
        {
            return await dbcollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<Item> GetItemAsync(Guid Id)
        {
            FilterDefinition<Item> filter = filterBuilder.Eq(entity => entity.Id, Id);
            return await dbcollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateItemAsync(Item entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await dbcollection.InsertOneAsync(entity);
        }

        public async Task UpdateItemAsync(Item entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            FilterDefinition<Item> filter = filterBuilder.Eq(existingItem => existingItem.Id, entity.Id);
            await dbcollection.FindOneAndReplaceAsync(filter, entity);
        }

        public async Task DeleteItemAsync(Guid Id)
        {
            FilterDefinition<Item> filter = filterBuilder.Eq(entity => entity.Id, Id);
            await dbcollection.FindOneAndDeleteAsync(filter);
        }

    }
}