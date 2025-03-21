using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices;

public class ProductService:IProductService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Product> _productCollection;

    public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        var products = await _productCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDto>>(products);
    }

    public async Task CreateProductAsync(CreateProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productCollection.InsertOneAsync(product);
    }

    public async Task UpdateProductAsync(UpdateProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productCollection.FindOneAndReplaceAsync(x=>x.ProductId == productDto.ProductId, product); 
    }

    public async Task DeleteProductAsync(string productId)
    {
        await  _productCollection.DeleteOneAsync(x => x.ProductId == productId);
    }

    public async Task<GetByIdProductDto> GetProductByIdAsync(string productId)
    {
        var product = await _productCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDto>(product);
    }
}