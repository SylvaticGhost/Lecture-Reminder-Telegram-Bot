using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace LectureReminder;

public class TelegramClient
{
    private readonly string _chatId;
    private readonly HttpClient _httpClient;
    private readonly string _url;

    public TelegramClient(string botToken, string chatId)
    {
        _url = $"https://api.telegram.org/bot{botToken}/sendMessage";
        _chatId = chatId;
        _httpClient = new HttpClient();
    }


    public void Send<T>(T obj)
    {
        var message = obj.ToString();

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var data = new
        {
            chat_id = _chatId,
            text = message
        };
        var json = JsonSerializer.Serialize(data);

        var resp = _httpClient.PostAsync(
            _url, new StringContent(json, Encoding.UTF8, "application/json"));
    }
}