using MongoDB.Driver;
using Restful5Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful5Catalog.Repositories
{
    public class MongoDBItemsRepository : IInMemItemsRepository
    {
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;
        public MongoDBItemsRepository(IMongoClient mongoClient)
        {
            //get instance of database
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            //reference to collection
            itemsCollection = database.GetCollection<Item>(collectionName);

        }
        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
