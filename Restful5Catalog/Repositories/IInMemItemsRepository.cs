using Restful5Catalog.Entities;
using System;
using System.Collections.Generic;

namespace Restful5Catalog.Repositories
{
    public interface IInMemItemsRepository
    {
        Item GetItem(Guid Id);
        IEnumerable<Item> GetItems();

        void CreateItem(Item item);

        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}