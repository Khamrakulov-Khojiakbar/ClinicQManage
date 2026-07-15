using AvangardQManagement.Domain.Interfaces;
using AvangardQManagement.Domain.Models;
using AvangardQManagement.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AvangardDbContext _dbContext;

    public UserRepository(AvangardDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await _dbContext.Users.AddAsync(user, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
        }
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _dbContext.Users.AsNoTracking().ToListAsync();
        return users;
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<User?> GetByIdAsync(Guid guid, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Id == guid);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
        if (existingUser != null)
        {
            _dbContext.Update(existingUser);
        }
    }
}
