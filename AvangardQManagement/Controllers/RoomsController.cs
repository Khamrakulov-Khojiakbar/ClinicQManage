using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AvangardQManagement.Application.Rooms.Queries;
using AvangardQManagement.Application.DataTransferObject.RoomDTO;
using AvangardQManagement.Application.Rooms.Commands.CreateRooom;

namespace AvangardQManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly IMediator mediator;

    public RoomsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRooms(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllRoomsQuery(), cancellationToken);
            return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom(RoomDto roomDto, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateRoomCommand(roomDto.RoomNumber, roomDto.RoomName), cancellationToken);
        return Ok(result);
    }
}
