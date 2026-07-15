using AvangardQManagement.Domain.Auth;
using AvangardQManagement.Domain.Interfaces;
using AvangardQManagement.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Infrastructure.Repositories;

public class PermissionRepository : IPermissionRepository
{
    private readonly AvangardDbContext _dbContext;

    public PermissionRepository(AvangardDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        _dbContext.Permissions.Remove(new Permission { Id = id });
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Permission>> GetAllPermissionsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Permissions
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Permission?> GetPermissionByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var permission = await _dbContext.Permissions
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        return permission;
    }

    public async Task<Permission?> GetPermissionByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var permission = await _dbContext.Permissions
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Name == name, cancellationToken);
        return permission;
    }

    public Task UpdateAsync(Permission permission, CancellationToken cancellationToken = default)
    {
        _dbContext.Permissions.Update(permission);
        return Task.CompletedTask;
    }
}
