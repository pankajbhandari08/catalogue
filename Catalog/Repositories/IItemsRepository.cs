using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public interface IItemsRepository
    {
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Item> GetItemAsync(Guid id);

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Item>> GetItemsAsync();

        /// <summary>
        /// Creates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        Task CreateItemAsync(Item item);

        /// <summary>
        /// Updates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        Task UpdateItemAsync(Item item);

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task DeleteItemAsync(Guid id);
    }
}