using System.Threading.Tasks;

namespace IAEGoogleDrie.Messaging.Handling
{
    public interface IDynamicEventHandler
    {
        Task HandleAsync(dynamic eventData);
    }
}