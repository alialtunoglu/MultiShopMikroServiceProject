using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices;

public class CategoryService: ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection; //veri tabanındaki category collectionu
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
         var values = await _categoryCollection.Find(x=>true).ToListAsync();
         return _mapper.Map<List<ResultCategoryDto>>(values);
    }

    public async Task CreateCategoryAsync(CreateCategoryDto categoryDto)
    {
        var value = _mapper.Map<Category>(categoryDto);
        await _categoryCollection.InsertOneAsync(value);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto categoryDto)
    {
        var values = _mapper.Map<Category>(categoryDto);
        await _categoryCollection.FindOneAndReplaceAsync(x=> x.CategoryID == categoryDto.CategoryID, values); 
    }

    public async Task DeleteCategoryAsync(string categoryId)
    {
        await _categoryCollection.DeleteOneAsync(x=> x.CategoryID == categoryId);
    }

    public async Task<GetByIdCategoryDto> GetCategoryByIdAsync(string categoryId)
    {
        var category = await _categoryCollection.Find(x=>x.CategoryID == categoryId).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdCategoryDto>(category);
    }
}