using AvangardQManagement.Application.DataTransferObject.TicketsDTO;
using AvangardQManagement.Application.Tickets.Commands;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvangardQManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/createticket")]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDto dto, CancellationToken cancellationToken)
        {
            var command = dto.Adapt<CreateTicketCommand>();
            var ticketId = await _mediator.Send(command);

            return Ok(new { TicketId = ticketId });
        }


        [HttpPut("/updateticket")]
        public async Task<IActionResult> UpdateTicket([FromBody] UpdateTicketStatusDto dto, CancellationToken cancellationToken)
        {
            var command = dto.Adapt<UpdateTicketStatusCommand>();
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(new { Success = result });
        }

    }
}
