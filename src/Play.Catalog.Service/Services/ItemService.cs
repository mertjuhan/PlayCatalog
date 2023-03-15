using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Interfaces;

namespace Play.Catalog.Service.Services
{

    public class ItemService : IItemService
    {
        private static readonly List<ItemDto> items = new() {

        new ItemDto(Guid.NewGuid() ," Alimünyum","Çok İyi",14.99,DateTimeOffset.UtcNow),
        new ItemDto(Guid.NewGuid() ," Alimünyum","Çok İyi",14.99,DateTimeOffset.UtcNow),
        new ItemDto(Guid.NewGuid() ," Alimünyum","Çok İyi",14.99,DateTimeOffset.UtcNow)

    };

        public Task<IEnumerable<ItemDto>> GetItems()
        {
            return Task.FromResult(items.AsEnumerable());
        }

        public Task<IEnumerable<ItemDto>> GetItemsById(Guid Id)
        {
            return Task.FromResult(items.Where(x => x.Id == Id));
        }

        public Task<IEnumerable<ItemDto>> CreateItem(CreateItemDto createItemDto)
        {

            var Id = Guid.NewGuid();
            items.Add(
                new ItemDto(Id, createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow)
            );

            return Task.FromResult(items.Where(x => x.Id == Id).AsEnumerable());
        }
    }
}