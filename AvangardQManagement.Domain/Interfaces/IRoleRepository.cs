using AvangardQManagement.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Domain.Interfaces;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllRolesAsync(CancellationToken cancellationToken = default);
    Task<Role?> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Role?> GetRoleByNameAsync(string name, CancellationToken cancellationToken = default);
    Task CreateRoleAsync(Role role, CancellationToken cancellationToken = default);
    Task UpdateRoleAsync(Role role, CancellationToken cancellationToken = default);
    Task DeleteRoleAsync(Guid id, CancellationToken cancellationToken = default);
}
