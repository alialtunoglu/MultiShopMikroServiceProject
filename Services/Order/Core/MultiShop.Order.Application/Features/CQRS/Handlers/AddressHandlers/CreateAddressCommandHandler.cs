using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Adress> _repository;

        public CreateAddressCommandHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }
        //Her sınıf sadece bir işlem yapmalı !!
        //Handle CQRS ve Mediator Design patternda kullanılan metot ismidir !! opsiyoneldir ama genelde bu isim kullanılır
        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Adress{
                City = createAddressCommand.City,
                Detail = createAddressCommand.Detail,
                District = createAddressCommand.District,
                UserId = createAddressCommand.UserId
            });
        }
    }
}