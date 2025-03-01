using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAdressCommandHandler
    {
        private readonly IRepository<Adress> _repository;

        public RemoveAdressCommandHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAddressCommand removeAddressCommand)
        {
            var value = await _repository.GetByIdAsync(removeAddressCommand.Id);
            await _repository.DeleteAsync(value);
        }
    }
}