using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Interfaces;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _service;
        public ItemsController(IItemService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItems()
        {

            return await _service.GetItems();
        }

        [HttpGet("{Id}")]
        public async Task<IEnumerable<ItemDto>> GetItemsById(Guid Id)
        {

            return await _service.GetItemsById(Id);
        }

        [HttpPost("/CreateItem")]

        public async Task<IEnumerable<ItemDto>> CreateItem(CreateItemDto createItemDto)
        {

            return await _service.CreateItem(createItemDto);
        }

        [HttpPost("/UpdateItem")]

        public async Task<IEnumerable<ItemDto>> UpdateItem(Guid Id, UpdateItemDto updateItemDto)
        {

            return await _service.UpdateItem(Id, updateItemDto);
        }


        [HttpDelete("{Id}")]

        public async Task<bool> DeleteItem(Guid Id)
        {

            return await _service.DeleteItem(Id);
        }
    }
}