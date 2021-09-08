using Catalog.DTO;
using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog
{
    public static class Extension
    {
        public static ItemDTO GetItemDTO(this Item item)
        {
            return new ItemDTO()
            {
                CreatedDate = item.CreatedDate,
                Id = item.Id,
                Name = item.Name,
                Price = item.Price
            };
        }
    }
}
