namespace AvangardQManagement.Application.DataTransferObject.UserDTO;


public record AuthResponceDto
(
    string Token,
    UserDto UserDto,
    DateTime ExpiresAt
);