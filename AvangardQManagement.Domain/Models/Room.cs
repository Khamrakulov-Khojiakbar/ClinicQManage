using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Domain.Models;

public class Room
{
    public int Id { get; set; }
    public int RoomNumber { get; set; }
    public string RoomName { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; } = new List<User>();
}
