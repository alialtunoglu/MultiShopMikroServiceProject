using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
<<<<<<< HEAD
        public async Task<IActionResult> OrderingById(int id)
        {
            var values = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(values);
=======
        public async Task<IActionResult> GetOrderById(int id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(value);
>>>>>>> fb8b6cec80a23fbef5fae153b05d1a16f26f16ca
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla eklendi");
        }
<<<<<<< HEAD
=======
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sipariş başarıyla silindi");
        }
>>>>>>> fb8b6cec80a23fbef5fae153b05d1a16f26f16ca
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla güncellendi");
        }
<<<<<<< HEAD
        [HttpDelete()]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sipariş başarıyla silindi");
        }
=======
>>>>>>> fb8b6cec80a23fbef5fae153b05d1a16f26f16ca

    }
}
