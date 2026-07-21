using AvangardQManagement.Application.Common.Interfaces;
using AvangardQManagement.Domain.Enums;
using AvangardQManagement.Domain.Interfaces;
using AvangardQManagement.Domain.Models;
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

        
        string prefix = GeneratePrefixFromName(reception.ReceptionName);

        var allTickets = await _ticketRepository.GetAllAsync();
        var todayTickets = allTickets
            .Where(t => t.CreatedAt.Date == DateTime.UtcNow.Date
            && t.TicketNumber.StartsWith($"{prefix}-"));

        int nextNumber = 1;
        if(todayTickets.Any())
        {
            var maxNumber = todayTickets
                .Select(t => int.TryParse(t.TicketNumber.Replace($"{prefix}-", ""), out var num) ? num : 0)
                .Max();
        
            nextNumber = maxNumber + 1;

        }

        var generatedTicketNumber = $"{prefix}-{nextNumber}";

        var ticket = new Ticket
        {
            Id = Guid.NewGuid(),
            RoomId = request.RoomId,
            ReceptionId = request.ReceptionId,
            UserId = request.UserId,
            Status = StatusEnum.Waiting,
            CreatedAt = DateTime.UtcNow,
            TicketNumber = generatedTicketNumber
        };

        await _ticketRepository.CreateTicketAsync(ticket, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ticket.Id;
    }

    private string GeneratePrefixFromName(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            return "T";
        }

        var firstWord = name.Trim()
            .Split(' ')[0]
            .Replace("-", "")
            .ToUpper();

        if(firstWord.Length <= 4)
        {
            return firstWord;
        }

        return firstWord.Substring(0, Math.Min(4, firstWord.Length));

    }
}
