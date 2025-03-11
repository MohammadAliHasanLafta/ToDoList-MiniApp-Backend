
namespace ToDoApi.Core.ToDoDtosProfiles.Dtos;

public class VerifyInitdataDto
{
    public long UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Initdata { get; set; }
    public string? IpAddress { get; set; }
}
