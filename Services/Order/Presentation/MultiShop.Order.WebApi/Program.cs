using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Interfaces;   
using MultiShop.Order.Application.Services;   
using MultiShop.Order.Persistance.Context;
using MultiShop.Order.Persistance.Repositories;
using MultiShop.Order.Application.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddApplicationService(builder.Configuration);


builder.Services.AddDbContext<OrderContext>();

// Add services to the container.

<<<<<<< HEAD
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddApplicationServices(builder.Configuration);

#region 
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
=======
#region 
>>>>>>> fb8b6cec80a23fbef5fae153b05d1a16f26f16ca
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<GetAddressQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAdressCommandHandler>();

builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
#endregion
<<<<<<< HEAD

=======
>>>>>>> fb8b6cec80a23fbef5fae153b05d1a16f26f16ca

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
