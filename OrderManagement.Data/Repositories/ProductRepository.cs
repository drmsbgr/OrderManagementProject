using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Models;
using OrderManagement.Data.Contracts;

namespace OrderManagement.Data.Repositories;

public class ProductRepository(AppDbContext dbContext) : IProductRepository
{
    public async Task AddAsync(Product entity)
    {
        await dbContext.Products.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await dbContext.Products.FindAsync(id);
    }

    public void Update(Product entity)
    {
        dbContext.Products.Update(entity);
    }
}
