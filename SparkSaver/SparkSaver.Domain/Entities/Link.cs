namespace SparkSaver.Domain.Entities;

public class Link : BaseEntity
{
    public required string Url { get; set; }

    public long ChatId { get; set; }
}
