namespace AvangardQManagement.Application.DataTransferObject.UserDTO;

public record LoginRequestDto
(
    string Email,
    string Password
);