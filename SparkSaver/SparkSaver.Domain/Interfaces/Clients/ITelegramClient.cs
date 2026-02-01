namespace SparkSaver.Domain.Interfaces.Clients;

public interface ITelegramClient
{
    public Task SendMessageAsync(string message, long chatId, CancellationToken ct);
}
