using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Models;
using OrderManagement.Data.Contracts;

namespace OrderManagement.Data.Repositories;

public class OrderRepository(AppDbContext dbContext) : IOrderRepository
{
    public async Task AddAsync(Order entity)
    {
        await dbContext.Orders.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await dbContext.Orders.ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await dbContext.Orders.FindAsync(id);
    }

    public async Task<IEnumerable<Order>> GetOrdersWithDetailsAsync(Guid customerId)
    {
        return await dbContext.Orders.Where(x => x.CustomerId == customerId).ToListAsync();
    }

    public void Update(Order entity)
    {
        dbContext.Orders.Update(entity);
    }
}
