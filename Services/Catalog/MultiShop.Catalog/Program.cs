using System.Reflection;
using Microsoft.Extensions.Options;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Settings;
using dotenv.net;

DotEnv.Load();
var envVars = DotEnv.Read();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration["DatabaseSettings:ConnectionString"] = envVars["DATABASE_CONNECTION_STRING"];

builder.Services.AddScoped<ICategoryService,CategoryService>(); //ICategoryService arayüzü istendiğinde CategoryService sınıfının bir örneğini sağlar.
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IProductDetailService,ProductDetailService>();
builder.Services.AddScoped<IProductImageService,ProductImageService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //AutoMapper kütüphanesini projeye ekler.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings")); //DatabaseSettings sınıfını appsettings.json dosyasındaki DatabaseSettings bölümüne bağlar.
builder.Services.AddScoped<IDatabaseSettings>(sp=>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
