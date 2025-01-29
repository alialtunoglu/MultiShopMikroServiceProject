using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices;

public class ProductImageService:IProductImageService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductImage> _productImageCollection;

    public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        var productImage = await _productImageCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductImageDto>>(productImage);
    }

    public async Task CreateProductImageAsync(CreateProductImageDto productImageDto)
    {
        var productImage = _mapper.Map<ProductImage>(productImageDto);
        await _productImageCollection.InsertOneAsync(productImage);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto productImageDto)
    {
        var productImage = _mapper.Map<ProductImage>(productImageDto);
        await  _productImageCollection.FindOneAndReplaceAsync(x=>x.ProductImageID==productImageDto.ProductImageID,productImage);
        
    }

    public async Task DeleteProductImageAsync(string productImageId)
    {
        await _productImageCollection.DeleteOneAsync(x => x.ProductImageID == productImageId);
    }

    public async Task<GetByIdProductImageDto> GetProductImageByIdAsync(string productImageId)
    {
        var productImage = await _productImageCollection.Find(x => x.ProductImageID == productImageId).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductImageDto>(productImage);
    }
}