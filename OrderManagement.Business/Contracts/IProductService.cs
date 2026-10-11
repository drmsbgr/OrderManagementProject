using OrderManagement.Core.Dtos;

namespace OrderManagement.Business.Contracts;

public interface IProductService
{
    Task<ICollection<ProductDto>> GetAllProductsAsync();
    Task CreateProductAsync(ProductCreateDto prod);
}
