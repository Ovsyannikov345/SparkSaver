using SparkSaver.Domain.Interfaces.Clients;
using SparkSaver.Infrastructure.HttpClients.Telegram.Requests;
using System.Net.Http.Json;
using System.Text.Json;

namespace SparkSaver.Infrastructure.HttpClients.Telegram;

public sealed class TelegramClient(HttpClient httpClient) : ITelegramClient
{
    private const string MessageEndpointUrl = "sendMessage";

    private readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
    };

    public async Task SendMessageAsync(string message, long chatId, CancellationToken ct)
    {
        var request = new SendMessageRequest
        {
            Text = message,
            ChatId = chatId,
        };

        var response = await httpClient.PostAsJsonAsync(MessageEndpointUrl, request, SerializerOptions, ct);

        Console.WriteLine();
    }
}
