using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public class MemoryItemsRepository : IItemsRepository
    {
        private readonly List<Item> Items = new()
        {
            new Item() { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item() { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item() { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow }
        };

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Item> GetItems()
        {
            return Items;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Item GetItem(Guid id)
        {
            return Items.Where(item => item.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// Creates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void CreateItem(Item item)
        {
            Items.Add(item);
        }

        /// <summary>
        /// Updates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void UpdateItem(Item item)
        {
            var index = Items.FindIndex(exisitingItem => exisitingItem.Id == item.Id);

            Items[index] = item;
        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteItem(Guid id)
        {
            var index = Items.FindIndex(exisitingItem => exisitingItem.Id == id);
            Items.RemoveAt(index);
        }
    }
}
