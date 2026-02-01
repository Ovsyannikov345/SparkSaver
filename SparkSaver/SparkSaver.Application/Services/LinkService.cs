using SparkSaver.Application.Dto;
using SparkSaver.Domain.Entities;
using SparkSaver.Domain.Interfaces;
using SparkSaver.Domain.Interfaces.Clients;

namespace SparkSaver.Application.Services;

public interface ILinkService
{
    public Task SaveLinkAsync(SaveLinkRequest request, CancellationToken ct);
}

public sealed class LinkService(
    ITelegramClient telegramClient,
    IApplicationDbContext dbContext)
    : ILinkService
{
    public async Task SaveLinkAsync(SaveLinkRequest request, CancellationToken ct)
    {
        var link = new Link
        {
            Url = request.Url,
            ChatId = request.ChatId,
        };

        dbContext.Add(link);
        await dbContext.SaveChangesAsync(ct);

        await telegramClient.SendMessageAsync("Link has been saved!", request.ChatId, ct);
    }
}
