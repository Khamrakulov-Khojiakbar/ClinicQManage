namespace AvangardQManagement.Application.DataTransferObject.TicketsDTO;


public record TicketDto
{
    public Guid Id{get; init;}
    public string TicketNumber { get; init; } = string.Empty;
    public int RoomId { get; init; }
    public string RoomName { get; init; } = string.Empty;
    public int ReceptionId { get; init; }
    public string ReceptionName { get; init; } = string.Empty;
    public Guid? UserId { get; init; }
    public string? UserName { get; init; }
    public string Status { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime? CalledAt { get; init; }
}