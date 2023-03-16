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
        public Task<IEnumerable<ItemDto>> UpdateItem(Guid Id, UpdateItemDto updateItemDto)
        {

            var item = items.Where(x => x.Id == Id).FirstOrDefault();

            if (item != null)
            {
                var updateditem = item with
                {
                    Name = updateItemDto.Name,
                    Description = updateItemDto.Description,
                    Price = updateItemDto.Price
                };

                var index = items.FindIndex(x => x.Id == Id);
                items[index] = updateditem;
            }

            return Task.FromResult(items.Where(x => x.Id == Id).AsEnumerable());
        }

        public Task<bool> DeleteItem(Guid Id)
        {

            var item = items.Where(x => x.Id == Id).FirstOrDefault();
            if (item != null)
            {
                var result = items.Remove(item);
                return Task.FromResult(result);
            }


            return Task.FromResult(false);

        }


    }

}