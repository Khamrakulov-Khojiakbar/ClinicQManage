using AvangardQManagement.Domain.Auth;
using AvangardQManagement.Domain.Interfaces;
using AvangardQManagement.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly AvangardDbContext _dbContext;

    public RoleRepository(AvangardDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task CreateRoleAsync(Role role, CancellationToken cancellationToken = default)
    {
        _dbContext.Roles.Add(role);
        return Task.CompletedTask;
    }

    public async Task DeleteRoleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existRole = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
        if (existRole != null)
        {
            _dbContext.Roles.Remove(existRole);
        }
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Roles
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Role?> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Roles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Role?> GetRoleByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Roles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.RoleName == name, cancellationToken);
    }

    public Task UpdateRoleAsync(Role role, CancellationToken cancellationToken = default)
    {
        _dbContext.Roles.Update(role);
        return Task.CompletedTask;
    }
}
