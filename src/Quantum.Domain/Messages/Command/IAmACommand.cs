public interface IAmACommand : ICloneable
{
    MessageMetadata Metadata { get; set; }
    string GetCorrelationId();
    string GetId();
    void SetCorrelationId(string correlationId);
}

namespace Quantum.Domain.Messages.Command
{
    public class IsACommand : IAmACommand
    {
        public MessageMetadata Metadata { get; set; }
        public IsACommand()
            => Metadata = new MessageMetadata($"cmd-{Guid.NewGuid()}", GetType().AssemblyQualifiedName);

        public string GetId() => Metadata.Id;

        public void SetCorrelationId(string correlationId)
            => Metadata.SetCorrelationId(correlationId);

        public string GetCorrelationId() => Metadata.CorrelationId;
        public object Clone()
        {
            return new IsACommand
            {
                Metadata = (MessageMetadata)Metadata.Clone()
            };
        }
    }
}