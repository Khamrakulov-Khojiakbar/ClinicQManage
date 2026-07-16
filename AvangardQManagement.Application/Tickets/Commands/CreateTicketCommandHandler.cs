using AvangardQManagement.Application.Common.Interfaces;
using AvangardQManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Application.Tickets.Commands;

public record CreateTicketCommand(int RoomId, int ReceptionId, Guid? UserId) : IRequest<Guid>;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IReceptionRepository _receptionRepository;
    private readonly IUnitOfWork _unitOfWork;


    public CreateTicketCommandHandler(ITicketRepository ticketRepository, IReceptionRepository receptionRepository, IUnitOfWork unitOfWork)
    {
        _ticketRepository = ticketRepository;
        _receptionRepository = receptionRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var reception = await _receptionRepository.GetReceptionByIdAsync(request.ReceptionId, cancellationToken);

        if(reception == null)
        {
            throw new InvalidOperationException("This service is not avalible");
        }

        Guid ran = Guid.NewGuid();

        return ran;
        
    }
}
