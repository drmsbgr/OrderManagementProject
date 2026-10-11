namespace OrderManagement.Core.Dtos;

public record OrderDto
{
    public DateTime OrderDate { get; init; }
    public decimal TotalPrice { get; init; }
    public ICollection<ProductDto> Products { get; init; } = [];
}