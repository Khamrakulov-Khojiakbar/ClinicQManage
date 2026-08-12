using AvangardQManagement.Application.DataTransferObject.TicketsDTO;
using AvangardQManagement.Domain.Interfaces;
using Mapster;
using MediatR;

namespace AvangardQManagement.Application.Tickets.Queries;


public record GetAllTicketsQuery : IRequest<List<TicketDto>>;

public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, List<TicketDto>>
{
    private readonly ITicketRepository _ticketRepository;

    public GetAllTicketsQueryHandler(ITicketRepository _ticketRepository)
    {
        this._ticketRepository = _ticketRepository;
    }


    public async Task<List<TicketDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _ticketRepository.GetAllAsync();
        return tickets.Adapt<List<TicketDto>>();
    }
}