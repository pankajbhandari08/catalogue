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
        public async Task<IEnumerable<ItemDTO>> GetItemsAsync()
        {
            //this is one way of converting item to itemDTO
            //return repository.GetItems().Select(item => new ItemDTO()
            //{
            //    Id = item.Id,
            //    CreatedDate = item.CreatedDate,
            //    Name = item.Name,
            //    Price = item.Price
            //});
            return (await repository.GetItemsAsync()).Select(item => item.GetItemDTO());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItemAsync(Guid Id)
        {
            var item = await repository.GetItemAsync(Id);

            if (item == null)
            {
                return NotFound();
            }

            return item.GetItemDTO();
        }

        //POST /items
        [HttpPost]
        public async Task<ActionResult<ItemDTO>> AddItemAsync(CreateItemDTO itemDTO)
        {
            Item item = new Item()
            {
                CreatedDate = DateTimeOffset.UtcNow,
                Id = Guid.NewGuid(),
                Name = itemDTO.Name,
                Price = itemDTO.Price
            };

            await repository .CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item);
        }


        //PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDTO itemDTO)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem == null)
                return NotFound();

            Item updatedItem = existingItem with
            {
                Name = itemDTO.Name,
                Price = itemDTO.Price
            };

            await repository.UpdateItemAsync(updatedItem);

            return NoContent();
        }


        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = repository.GetItemAsync(id);

            if (existingItem == null)
                return NotFound();

            await repository .DeleteItemAsync(id);

            return NoContent();
        }
    }
}
