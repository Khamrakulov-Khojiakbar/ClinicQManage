namespace AvangardQManagement.Application.DataTransferObject.TicketsDTO;

public record RoomQueueStatusDto
{
    public int RoomId{get; init;}
    public int RoomNumber{get; init;}
    public TicketDto? CurrentCallingTicket{get; init;}
    public List<TicketDto> WaitingTickets{get; init;} = new();
}