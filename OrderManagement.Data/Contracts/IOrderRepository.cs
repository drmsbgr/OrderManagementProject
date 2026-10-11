using OrderManagement.Core.Models;

namespace OrderManagement.Data.Contracts;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersWithDetailsAsync(Guid customerId);
}
