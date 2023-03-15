using Play.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetItems();
        Task<IEnumerable<ItemDto>> GetItemsById(Guid Id);
        Task<IEnumerable<ItemDto>> CreateItem(CreateItemDto createItemDto);
    }
}