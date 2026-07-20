namespace AvangardQManagement.Application.DataTransferObject.TicketsDTO;

public record MainScreenSummaryDto
{
    public DateTime ServerTime {get; init;} = DateTime.UtcNow;
    public List<RoomQueueStatusDto> Rooms {get; init;} = new();
}