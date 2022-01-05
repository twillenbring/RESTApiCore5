using Microsoft.AspNetCore.Mvc;
using Restful5Catalog.Dtos;
using Restful5Catalog.Entities;
using Restful5Catalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful5Catalog.Controllers
{

    
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemItemsRepository _repository;

        public ItemsController(IInMemItemsRepository repository)
        {
            _repository = repository;
        }
        //Get /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            //AsDto: extension method convert model to DTO 
            var item = _repository.GetItems().Select(item => item.AsDto());
            
            return item;
        }
        //Get /items/id
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid Id)
        {
            var item = _repository.GetItem(Id);
            if(item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }
        //Post /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            _repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { Id = item.Id }, item.AsDto());
        }

        //Put /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid Id, CreateItemDto itemDto)
        {
            var existingItem = _repository.GetItem(Id);
            if(existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            _repository.UpdateItem(updatedItem);

            return NoContent();
        }
        //Delete /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = _repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            _repository.DeleteItem(id);

            return NoContent();
        }
    }
}
