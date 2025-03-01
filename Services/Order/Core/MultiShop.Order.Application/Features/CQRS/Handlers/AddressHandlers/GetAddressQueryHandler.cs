using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Adress> _repository;

        public GetAddressQueryHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var addresses = await _repository.GetAllAsync();
            return addresses.Select(x => new GetAddressQueryResult
            {
                AdressId = x.AdressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId
            }).ToList();
        }
    }
}