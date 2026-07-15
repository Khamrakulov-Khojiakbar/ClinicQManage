using AvangardQManagement.Domain.Enums;
using AvangardQManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Domain.Interfaces;

public interface ITicketRepository
{
    Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Ticket>> GetAllWithStatusAsync(StatusEnum status, CancellationToken cancellationToken = default);

    Task CreateTicketAsync(Ticket ticket, CancellationToken cancellationToken = default);
    Task UpdateTicketAsync(Ticket ticket, CancellationToken cancellationToken = default);

    Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Ticket>> GetTicketsByRoomIdAsync(int roomId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Ticket>> GetAllAsync();
    Task DeleteTicketAsync(Guid id);


}
