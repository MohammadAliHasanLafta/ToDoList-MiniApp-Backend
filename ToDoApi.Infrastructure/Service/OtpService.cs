
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Infrastructure.Service;

public class OtpService : IOtpService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "KaveNegar_API_Key";

    public OtpService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> SendOtpAsync(string phoneNumber, string message)
    {
        var requestUri = $"https://api.kavenegar.com/v1/{_apiKey}/sms/send.json";
        var requestContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("receptor", phoneNumber),
            new KeyValuePair<string, string>("message", message)
        });

        var response = await _httpClient.PostAsync(requestUri, requestContent);
        return response.IsSuccessStatusCode;
    }
}
