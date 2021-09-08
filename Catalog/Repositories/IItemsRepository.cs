using Catalog.Entities;
using System;
using System.Collections.Generic;

namespace Catalog.Repositories
{
    public interface IItemsRepository
    {
        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Item GetItem(Guid id);

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Item> GetItems();

        /// <summary>
        /// Creates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void CreateItem(Item item);
    }
}