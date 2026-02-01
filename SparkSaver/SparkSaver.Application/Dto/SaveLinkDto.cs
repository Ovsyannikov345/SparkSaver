namespace SparkSaver.Application.Dto;

public sealed record SaveLinkRequest
{
    public required string Url { get; init; }

    public long ChatId { get; init; }
}
