namespace SparkSaver.Infrastructure.HttpClients.Telegram.Requests;

/// <summary>
/// See https://core.telegram.org/bots/api#sendmessage for details.
/// </summary>
public sealed record SendMessageRequest
{
    public long ChatId { get; init; }

    public required string Text { get; init; }
}
