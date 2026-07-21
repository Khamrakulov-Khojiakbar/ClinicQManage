using AvangardQManagement.Application.Common.Interfaces;
using AvangardQManagement.Domain.Interfaces;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Application.Rooms.Commands.CreateRooom;

public record UpdateRoomCommand
(
    int Id,
    int RoomNumber,
    string RoomName
) : IRequest<bool>;


public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, bool>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoomCommandHandler(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
    {
        _roomRepository = roomRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.Id, cancellationToken);
        if(room == null)
        {
            throw new KeyNotFoundException($"Room with {request.Id} not found");
        }

        if(room.RoomNumber != request.RoomNumber)
        {
            var existing = await _roomRepository.GetByNumberAsync(request.RoomNumber, cancellationToken);
            if(existing != null)
            {
                throw new InvalidOperationException($"Room with {request.RoomNumber} is existing");
            }

        }

        request.Adapt(room);

        await _roomRepository.UpdateRoomAsync(room, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}

