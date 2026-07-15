using AvangardQManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Domain.Interfaces;

public interface IReceptionRepository
{
    Task<Reception> GetReceptionByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Reception>> GetAllReceptionsAsync(CancellationToken cancellationToken = default);
    Task<Reception> CreateReceptionAsync(Reception reception, CancellationToken cancellationToken = default);
    Task ReceptionUpdateAsync(Reception reception, CancellationToken cancellationToken = default);
    Task ReceptionDeleteAsync(int id, CancellationToken cancellationToken = default);
}
