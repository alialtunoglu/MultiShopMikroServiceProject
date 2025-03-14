using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly RemoveAdressCommandHandler _removeAdressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;


        public AddressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAdressCommandHandler removeAdressCommandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAdressCommandHandler = removeAdressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressesList()
        {
            var addresses = await _getAddressQueryHandler.Handle();
            return Ok(addresses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AddressById(int id)
        {
            var address = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(address);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand createAddressCommand)
        {
            await _createAddressCommandHandler.Handle(createAddressCommand);
            return Ok("Ekleme işlemi başarıyla gerçekleşti");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAdressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Silme işlemi başarıyla gerçekleşti");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
        {
            await _updateAddressCommandHandler.Handle(updateAddressCommand);
            return Ok("Güncelleme işlemi başarıyla gerçekleşti");
        }
    }
}