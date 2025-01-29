using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProductAsync();
    Task CreateProductAsync(CreateProductDto productDto);
    Task UpdateProductAsync(UpdateProductDto productDto);
    Task DeleteProductAsync(string productId);
    Task<GetByIdProductDto> GetProductByIdAsync(string productId);
}