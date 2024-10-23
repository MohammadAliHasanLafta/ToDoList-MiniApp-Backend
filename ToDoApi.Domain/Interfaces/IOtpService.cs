
namespace ToDoApi.Domain.Interfaces;

public interface IOtpService
{
    Task<bool> SendOtpAsync(string phoneNumber, string message);
}
