using AvangardQManagement.Domain.Interfaces;
using AvangardQManagement.Domain.Models;
using AvangardQManagement.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Infrastructure.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly AvangardDbContext _dbContext;

    public RoomRepository(AvangardDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task CreateRoomAsync(Room room, CancellationToken cancellationToken = default)
    {
        _dbContext.Rooms.Add(room);
        return Task.CompletedTask;
    }

    public async Task DeleteRoomAsync(int id, CancellationToken cancellationToken = default)
    {
        var room = await _dbContext.Rooms.FirstOrDefaultAsync(r => r.Id == id);
        if (room != null)
        {
            _dbContext.Rooms.Remove(room);
        }
    }

    public async Task<IEnumerable<Room>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Rooms
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Room?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Rooms
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Room?> GetRoomByUser(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Rooms
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Users.Any(u => u.Id == userId), cancellationToken);
    }

    public Task UpdateRoomAsync(Room room, CancellationToken cancellationToken = default)
    {
        _dbContext.Rooms.Update(room);
        return Task.CompletedTask;
    }
}
