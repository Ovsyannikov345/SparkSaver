using System.ComponentModel.DataAnnotations;

namespace SparkSaver.Application.Configuration;

public class TelegramSettings
{
    public const string SectionName = "Telegram";

    [Required]
    public required string BotId { get; set; }

    [Url]
    [Required]
    public required string ApiUrl { get; set; }
}
