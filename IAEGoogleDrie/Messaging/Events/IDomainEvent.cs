using System;
using MediatR;

namespace IAEGoogleDrie.Messaging.Events
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }
        DateTime CreationDate { get; }
    }
}