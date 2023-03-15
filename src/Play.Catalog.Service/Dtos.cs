namespace Play.Catalog.Service.Dtos

{

    public record ItemDto(Guid Id, string Name, string Description, double Price, DateTimeOffset CreateTime);

    public record CreateItemDto(string Name, string Description, double Price);

    public record UpdateItemDto(string Name, string Description, double Price);
}