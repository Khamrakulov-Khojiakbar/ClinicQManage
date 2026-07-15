using AvangardQManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Domain.Models;

public class Ticket
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string TicketNumber { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public StatusEnum Status { get; set; } = StatusEnum.Waiting;
    public decimal TotalPrice { get; set; }

    public int ReceptionId { get; set; }
    public Reception Reception { get; set; } = null!;

    public int RoomId { get; set; }
    public Room Room { get; set; } = null!;


    public Guid? UserId { get; set; }
    public User? User { get; set; } = null!;
}
