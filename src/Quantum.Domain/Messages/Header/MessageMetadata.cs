namespace Quantum.Domain.Messages.Header;

public class MessageMetadata(string id, string type) : ICloneable
{
    public string Id { get; set; } = id;
    public string SideEffectOf { get; set; }
    public string ServiceName { get; set; }
    public string CreatedBy { get; set; }
    public string CreatedByUrl { get; set; }
    public string CorrelationId { get; set; }
    public DateTimeOffset OccurredAt { get; set; } = DateTime.UtcNow;
    public Version Version { get; set; } = new()
    {
        Major = 1
    };

    public Headers Headers { get; set; }
    public string Type { get; set; } = type;

    public void SetCorrelationId(string correlationId)
    {
        CorrelationId = correlationId;
    }

    public object Clone()
    {
        return new MessageMetadata(Id, Type)
        {
            CorrelationId = CorrelationId,
            OccurredAt = OccurredAt,
            Version = new Version { Major = Version.Major },
            Id = Id,
            CreatedBy = CreatedBy,
            ServiceName = ServiceName,
            SideEffectOf = SideEffectOf
        };
    }
}