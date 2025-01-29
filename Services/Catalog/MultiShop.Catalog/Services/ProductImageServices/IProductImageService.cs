using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices;

public interface IProductImageService
{
    Task<List<ResultProductImageDto>> GetAllProductImageAsync();
    Task CreateProductImageAsync(CreateProductImageDto productImageDto);
    Task UpdateProductImageAsync(UpdateProductImageDto productImageDto);
    Task DeleteProductImageAsync(string productImageId);
    Task<GetByIdProductImageDto> GetProductImageByIdAsync(string productImageId);
}