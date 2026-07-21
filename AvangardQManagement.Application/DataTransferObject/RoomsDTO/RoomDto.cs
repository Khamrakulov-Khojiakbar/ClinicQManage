namespace AvangardQManagement.Application.DataTransferObject.RoomDTO;

public record RoomDto
{
    public int Id {get; init;}
    public int RoomNumber{get; init;}
    public string RoomName { get; init; } = string.Empty;
        
}