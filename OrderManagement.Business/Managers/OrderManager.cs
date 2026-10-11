using OrderManagement.Business.Contracts;
using OrderManagement.Core.Dtos;
using OrderManagement.Core.Models;
using OrderManagement.Data.Contracts;

namespace OrderManagement.Business.Managers;

public class OrderManager(IOrderRepository _orderRepository, IProductRepository _productRepository) : IOrderService
{
    public async Task<bool> CreateOrderAsync(Guid customerId, List<Guid> productIds)
    {
        var order = new Order
        {
            CustomerId = customerId,
        };

        foreach (var id in productIds)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product is not null)
            {
                order.Products.Add(product);
                order.TotalPrice += product.Price;
            }
        }

        try
        {
            await _orderRepository.AddAsync(order);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<IEnumerable<OrderDto>> GetCustomerOrdersAsync(Guid customerId)
    {
        var orders = await _orderRepository.GetOrdersWithDetailsAsync(customerId);

        return orders.Select(x => new OrderDto()
        {
            OrderDate = x.OrderDate,
            TotalPrice = x.TotalPrice,
            Products = [.. x.Products.Select(p => new ProductDto() { Name = p.Name, Price = p.Price, StockQuantity = p.StockQuantity })]
        });
    }
}