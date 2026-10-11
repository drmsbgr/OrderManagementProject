namespace OrderManagement.Core.Dtos;


public record ProductCreateDto : ProductDto;

public record ProductDto
{
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public int StockQuantity { get; init; }
}
