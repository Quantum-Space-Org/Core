namespace Quantum.Domain.Messages.Command;

/// <summary>
///     Defines a Kafka message header.
/// </summary>
public interface IHeader
{
    /// <summary>
    ///     The header key.
    /// </summary>
    string Key { get; }

    /// <summary>
    ///     The serialized header value data.
    /// </summary>
    byte[] GetValueBytes();
}