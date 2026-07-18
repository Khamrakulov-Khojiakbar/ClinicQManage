using AvangardQManagement.Domain.Interfaces;
using AvangardQManagement.Domain.Models;
using AvangardQManagement.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Infrastructure.Repositories;

public class ReceptionRepository : IReceptionRepository
{
    private readonly AvangardDbContext _context;

    public ReceptionRepository(AvangardDbContext context)
    {
        _context = context;
    }
    public Task<Reception> CreateReceptionAsync(Reception reception, CancellationToken cancellationToken = default)
    {
        _context.Receptions.Add(reception);
        return Task.FromResult(reception);
    }

    public async Task<IEnumerable<Reception>> GetAllReceptionsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Receptions
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Reception> GetReceptionByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var reception = await _context.Receptions
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        if(reception == null)
        {
            throw new InvalidOperationException();
        }

        return reception;
    }

    public async Task ReceptionDeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var reception = await _context.Receptions.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        if (reception == null)
        {
            throw new InvalidOperationException();
        }
        _context.Receptions.Remove(reception);
    }

    public Task ReceptionUpdateAsync(Reception reception, CancellationToken cancellationToken = default)
    {
        _context.Receptions.Update(reception);
        return Task.CompletedTask;
    }
}
