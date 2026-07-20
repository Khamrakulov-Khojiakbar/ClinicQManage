namespace AvangardQManagement.Application.DataTransferObject.TicketsDTO;

public record UpdateTicketStatusDto
(
    Guid TicketId,
    string NewStatus,
    int? TargetRoomId = null
);