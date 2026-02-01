using Microsoft.AspNetCore.Mvc;
using SparkSaver.Application.Dto;
using SparkSaver.Application.Services;
using SparkSaver.Domain.Constants;
using System.Text.Json;

namespace SparkSaver.Controllers;

[ApiController]
[Route("webhooks")]
public class WebhooksController(ILinkService linkService) : ControllerBase
{
    [HttpPost("telegram")]
    public async Task<IActionResult> HandleTelegramWebhook(CancellationToken ct)
    {
        var request = await Request.ReadFromJsonAsync<TelegramUpdate>(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        });

        if (request?.Message?.Text is null || request.Message.Chat is null)
        {
            // TODO send response.
            return Ok();
        }

        var linkEntity = request.Message.Entities.FirstOrDefault(e => e.Type == TelegramMessageEntityTypes.Url);

        if (linkEntity is null)
        {
            // TODO send response.
            return Ok();
        }

        var link = request.Message.Text.Substring(linkEntity.Offset, linkEntity.Length);

        await linkService.SaveLinkAsync(new SaveLinkRequest { Url = link, ChatId = request.Message.Chat.Id }, ct);

        Console.WriteLine(request);

        return Ok();
    }
}

/// <summary>
/// Represent an incoming update. See https://core.telegram.org/bots/api#update for more details.
/// </summary>
public sealed record TelegramUpdate
{
    public int UpdateId { get; init; }

    public Message? Message { get; init; }

    public Message? EditedMessage { get; init; }
}

/// <summary>
/// Represents a message.
/// See https://core.telegram.org/bots/api#message for more details.
/// </summary>
public sealed record Message
{
    public int MessageId { get; init; }

    public int Date { get; init; }

    public string? Text { get; init; }

    public List<MessageEntity> Entities { get; init; } = [];

    public User? From { get; init; }

    public Chat? Chat { get; init; }
}

/// <summary>
/// Represents one special entity in a text message. For example, hashtags, usernames, URLs, etc.
/// See https://core.telegram.org/bots/api#messageentity for more details.
/// </summary>
public sealed record MessageEntity
{
    public required string Type { get; init; }

    public int Offset { get; init; }

    public int Length { get; init; }
}

/// <summary>
/// Represents a Telegram user or bot.
/// See https://core.telegram.org/bots/api#user for more details.
/// </summary>
public sealed record User
{
    public long Id { get; init; }

    public bool IsBot { get; init; }

    public required string FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Username { get; init; }

    public string? LanguageCode { get; init; }
}

/// <summary>
/// Represents a chat.
/// See https://core.telegram.org/bots/api#chat for more details.
/// </summary>
public sealed record Chat
{
    public long Id { get; init; }

    public required string Type { get; init; }

    public required string FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Username { get; init; }
}