using AvangardQManagement.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Domain.Interfaces;

public interface IPermissionRepository
{
    Task<IEnumerable<Permission>> GetAllPermissionsAsync(CancellationToken cancellationToken = default);
    Task<Permission?> GetPermissionByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Permission?> GetPermissionByNameAsync(string name, CancellationToken cancellationToken = default);
    Task UpdateAsync(Permission permission, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
