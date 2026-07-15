using AvangardQManagement.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Domain.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;


    public int? RoomId { get; set; }
    public Room? Room { get; set; }

    public ICollection<Reception> Receptions { get; set; } = new List<Reception>();
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

}
