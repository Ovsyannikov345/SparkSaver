using SparkSaver.Application.Dto;
using SparkSaver.Domain.Entities;
using SparkSaver.Domain.Interfaces;

namespace SparkSaver.Application.Services;

public interface ILinkService
{
    public Task SaveLinkAsync(SaveLinkRequest request, CancellationToken ct);
}

public sealed class LinkService(IApplicationDbContext dbContext) : ILinkService
{
    public async Task SaveLinkAsync(SaveLinkRequest request, CancellationToken ct)
    {
        var link = new Link
        {
            Url = request.Url
        };

        dbContext.Add(link);
        await dbContext.SaveChangesAsync(ct);
    }
}
