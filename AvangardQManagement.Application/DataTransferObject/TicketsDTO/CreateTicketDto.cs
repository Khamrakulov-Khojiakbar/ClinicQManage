namespace AvangardQManagement.Application.DataTransferObject.TicketsDTO;


public record CreateTicketDto
(
    int RoomId,
    int ReceptionId,
    Guid? UserId = null
);