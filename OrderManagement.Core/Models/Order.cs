namespace OrderManagement.Core.Models;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public decimal TotalPrice { get; set; }
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; } = null;
    public ICollection<Product> Products { get; set; } = [];

    public void CompleteOrder()
    {
        return;
    }
}

