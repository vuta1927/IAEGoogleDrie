using System.Threading.Tasks;

namespace IAEGoogleDrie.Messaging.Events
{
    public interface IEventService
    {
        Task SaveEventAsync(IEvent @event);
        Task MarkEventAsPublishedAsync(IEvent @event);
    }
}