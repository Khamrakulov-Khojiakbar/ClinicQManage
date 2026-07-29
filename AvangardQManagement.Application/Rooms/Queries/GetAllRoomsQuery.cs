using AvangardQManagement.Application.DataTransferObject.RoomDTO;
using AvangardQManagement.Application.DataTransferObject.RoomsDTO;
using AvangardQManagement.Domain.Interfaces;
using Mapster;
using MediatR;

namespace AvangardQManagement.Application.Rooms.Queries;

public record GetAllRoomsQuery : IRequest<List<RoomDto>>;

public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, List<RoomDto>>
{
    private readonly IRoomRepository _roomRepository;

    public GetAllRoomsQueryHandler(IRoomRepository _roomRepository)
    {
        this._roomRepository = _roomRepository;
    }



    public async Task<List<RoomDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await _roomRepository.GetAllAsync(cancellationToken);

        return rooms.Adapt<List<RoomDto>>();
    }
}