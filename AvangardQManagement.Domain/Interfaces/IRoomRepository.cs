using AvangardQManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Domain.Interfaces;

public interface IRoomRepository
{
    Task<Room?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Room?> GetRoomByUser(Guid userId, CancellationToken cancellationToken = default);
    Task<Room?> GetByNameAsync(string roomName, CancellationToken cancellationToken = default);
    Task<Room?> GetByNumberAsync(int roomNumber, CancellationToken cancellationToken = default);

    Task<IEnumerable<Room>> GetAllAsync(CancellationToken cancellationToken = default);

    Task CreateRoomAsync(Room room, CancellationToken cancellationToken = default);
    Task UpdateRoomAsync(Room room, CancellationToken cancellationToken = default);
    Task DeleteRoomAsync(int id, CancellationToken cancellationToken = default);

}
