namespace AvangardQManagement.Application.DataTransferObject.UserDTO;

public record UserDto
{
    public Guid Id {get; init;}
    public string Name {get; init;} = string.Empty;
    public string LastName {get; init;} = string.Empty;
    public string Position {get; init;} = string.Empty;
}