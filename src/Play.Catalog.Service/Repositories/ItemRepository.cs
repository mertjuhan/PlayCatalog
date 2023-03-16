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

        private readonly FilterDefinitionBuilder<Item>

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
            return null;
        }

    }
}