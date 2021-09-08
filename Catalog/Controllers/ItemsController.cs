using Catalog.DTO;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("[Controller]")] // GET /items
    //Or we can set the route like this [Route("Items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public IEnumerable<ItemDTO> GetItems()
        {
            //this is one way of converting item to itemDTO
            //return repository.GetItems().Select(item => new ItemDTO()
            //{
            //    Id = item.Id,
            //    CreatedDate = item.CreatedDate,
            //    Name = item.Name,
            //    Price = item.Price
            //});
            return repository.GetItems().Select(item => item.GetItemDTO());
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDTO> GetItem(Guid Id)
        {
            var item = repository.GetItem(Id);

            if (item == null)
            {
                return NotFound();
            }

            return item.GetItemDTO();
        }

        //POST /items
        [HttpPost]
        public ActionResult<ItemDTO> AddItem(CreateItemDTO itemDTO)
        {
            Item item = new Item()
            {
                CreatedDate = DateTimeOffset.UtcNow,
                Id = Guid.NewGuid(),
                Name = itemDTO.Name,
                Price = itemDTO.Price
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }
    }
}
