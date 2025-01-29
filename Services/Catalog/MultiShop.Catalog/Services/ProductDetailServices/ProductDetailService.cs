using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public class ProductDetailService: IProductDetailService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductDetail> _productDetailCollection;

    public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
    {
        var productDetails  = await _productDetailCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDto>>(productDetails);
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto productDetailDto)
    {
        var productDetail =_mapper.Map<ProductDetail>(productDetailDto);
        await _productDetailCollection.InsertOneAsync(productDetail);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto productDetailDto)
    {
        var productDetail = _mapper.Map<ProductDetail>(productDetailDto);
        await _productDetailCollection.FindOneAndReplaceAsync(x=>x.ProductDetailID==productDetailDto.ProductDetailID,productDetail);
    }

    public async Task DeleteProductDetailAsync(string productDetailId)
    {
        await  _productDetailCollection.DeleteOneAsync(x => x.ProductDetailID == productDetailId);
    }

    public async Task<GetByIdProductDetailDto> GetProductDetailByIdAsync(string productDetailId)
    {
        var productDetail = await _productDetailCollection.Find(x => x.ProductDetailID == productDetailId).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDetailDto>(productDetail);
    }
}