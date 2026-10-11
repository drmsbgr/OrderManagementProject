using OrderManagement.Core.Dtos;

namespace OrderManagement.Business.Contracts;

public interface IOrderService
{
    Task<bool> CreateOrderAsync(Guid customerId, List<Guid> productIds);
    Task<IEnumerable<OrderDto>> GetCustomerOrdersAsync(Guid customerId);
}
