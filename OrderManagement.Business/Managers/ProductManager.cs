using OrderManagement.Business.Contracts;
using OrderManagement.Core.Dtos;
using OrderManagement.Core.Models;
using OrderManagement.Data.Contracts;

namespace OrderManagement.Business.Managers;

public class ProductManager(IProductRepository _productRepository) : IProductService
{
    public async Task CreateProductAsync(ProductCreateDto prod)
    {
        var p = new Product()
        {
            Name = prod.Name,
            Price = prod.Price,
            StockQuantity = prod.StockQuantity
        };

        await _productRepository.AddAsync(p);
    }

    public async Task<ICollection<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return [.. products.Select(x => new ProductDto() { Name = x.Name, Price = x.Price, StockQuantity = x.StockQuantity })];
    }
}
