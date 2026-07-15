using AvangardQManagement.Domain.Enums;
using AvangardQManagement.Domain.Interfaces;
using AvangardQManagement.Domain.Models;
using AvangardQManagement.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Infrastructure.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly AvangardDbContext _context;

    public TicketRepository(AvangardDbContext context)
    {
        _context = context;
    }

    public async Task CreateTicketAsync(Ticket ticket, CancellationToken cancellationToken = default)
    {
        await _context.Tickets.AddAsync(ticket, cancellationToken);
    }

    public async Task DeleteTicketAsync(Guid id)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
        if (ticket != null)
        {
            _context.Tickets.Remove(ticket);
        }
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        return await _context.Tickets
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Ticket>> GetAllWithStatusAsync(StatusEnum status, CancellationToken cancellationToken = default)
    {
        var tickets = await _context.Tickets
            .AsNoTracking()
            .Where(t => t.Status == status)
            .ToListAsync();

        return tickets;
    }

    public async Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ticket = await _context.Tickets
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
        
        return ticket;
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByRoomIdAsync(int roomId, CancellationToken cancellationToken = default)
    {
        var tickets = await _context.Tickets
            .AsNoTracking()
            .Where(t => t.RoomId == roomId)
            .ToListAsync(cancellationToken);

        return tickets;
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var tickets = await _context.Tickets
            .AsNoTracking()
            .Where(t => t.UserId == userId)
            .ToListAsync(cancellationToken);

        return tickets;
    }

    public async Task UpdateTicketAsync(Ticket ticket, CancellationToken cancellationToken = default)
    {
        _context.Tickets.Update(ticket);

    }
}
