using System;

namespace IAEGoogleDrie.Messaging.Events
{
    public interface IEvent
    {
        Guid Id { get; }
        DateTime CreationDate { get; }
    }
}