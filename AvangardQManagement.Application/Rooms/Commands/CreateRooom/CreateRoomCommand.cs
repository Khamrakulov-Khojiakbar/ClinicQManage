using AvangardQManagement.Application.Common.Interfaces;
using AvangardQManagement.Domain.Interfaces;
using AvangardQManagement.Domain.Models;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Application.Rooms.Commands.CreateRooom;

public record CreateRoomCommand
(
    int RoomNumber,
    string RoomName
) : IRequest<int>;


public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, int>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoomCommandHandler(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
    {
        _roomRepository = roomRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var existingRoom = await _roomRepository.GetByIdAsync(request.RoomNumber, cancellationToken);
        if (existingRoom != null)
        {
            throw new InvalidOperationException($"Room with {request.RoomNumber} number is existing");
        }

        var room = request.Adapt<Room>();

        await _roomRepository.CreateRoomAsync(room, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return room.Id;
    }
}
