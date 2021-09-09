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
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(Items);
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Item> GetItemAsync(Guid id)
        {
            return await Task.FromResult(Items.Where(item => item.Id == id).SingleOrDefault());
        }

        /// <summary>
        /// Creates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public async Task CreateItemAsync(Item item)
        {
            Items.Add(item);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Updates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public async Task UpdateItemAsync(Item item)
        {
            var index = Items.FindIndex(exisitingItem => exisitingItem.Id == item.Id);

            Items[index] = item;

            await Task.CompletedTask;
        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task DeleteItemAsync(Guid id)
        {
            var index = Items.FindIndex(exisitingItem => exisitingItem.Id == id);
            Items.RemoveAt(index);

            await Task.CompletedTask;
        }
    }
}
