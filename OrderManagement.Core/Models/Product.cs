namespace OrderManagement.Core.Models;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public ICollection<Order> Orders { get; set; } = [];

    public void DecreaseStock(int quantity)
    {
        StockQuantity -= quantity;
    }
}

