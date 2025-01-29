using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public interface IProductDetailService
{
    
    Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
    Task CreateProductDetailAsync(CreateProductDetailDto productDetailDto);
    Task UpdateProductDetailAsync(UpdateProductDetailDto productDetailDto);
    Task DeleteProductDetailAsync(string productDetailId);
    Task<GetByIdProductDetailDto> GetProductDetailByIdAsync(string productDetailId);
}