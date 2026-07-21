using AvangardQManagement.Application.Common.Interfaces;
using AvangardQManagement.Application.DataTransferObject.TicketsDTO;
using AvangardQManagement.Domain.Enums;
using AvangardQManagement.Domain.Interfaces;
using Mapster;
using MediatR;


namespace AvangardQManagement.Application.Tickets.Commands;

public record UpdateTicketStatusCommand
    (
        Guid TicketId,
        StatusEnum NewStatus,
        int? TargetRoomId = null
    ) : IRequest<bool>;

public class UpdateTicketStatusCommandHandler : IRequestHandler<UpdateTicketStatusCommand, bool>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly IQueueNotificationService _queueNotificationService;

    public UpdateTicketStatusCommandHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork, IQueueNotificationService queueNotificationService)
    {
        _ticketRepository = ticketRepository;
        _unitOfWork = unitOfWork;
        _queueNotificationService = queueNotificationService;
    }

    public async Task<bool> Handle(UpdateTicketStatusCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetByIdAsync(request.TicketId, cancellationToken);

        if(ticket == null)
        {
            throw new KeyNotFoundException($"Ticket with {request.TicketId} is not found");
        }

        ticket.Status = request.NewStatus;

        if(request.TargetRoomId.HasValue)
        {
            ticket.RoomId = request.TargetRoomId.Value;
        }

        if(request.NewStatus == StatusEnum.Called)
        {
            ticket.CalledAt = DateTime.UtcNow;
        }

        await _ticketRepository.UpdateTicketAsync(ticket, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var ticketDto = ticket.Adapt<TicketDto>();

        await _queueNotificationService.NotifyTicketStatusChangedAsync(ticketDto, cancellationToken);
        await _queueNotificationService.NotifyQueueUpdatedAsync(ticketDto, cancellationToken);

        return true;

    }
}
