using AvangardQManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid guid, CancellationToken cancellationToken = default);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user, CancellationToken cancellationToken = default);
    Task UpdateAsync(User user, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

}
