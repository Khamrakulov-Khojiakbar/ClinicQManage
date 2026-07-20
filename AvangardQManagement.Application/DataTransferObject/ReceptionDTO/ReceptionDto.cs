namespace AvangardQManagement.Application.DataTransferObject.ReceptionDTO;

public record ReceptionDto
{
    public int Id {get; init;}
    public string ReceptionName {get; init;} = string.Empty;
    public decimal? Price {get; init;}
}