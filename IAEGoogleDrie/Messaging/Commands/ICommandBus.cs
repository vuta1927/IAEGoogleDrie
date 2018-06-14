using System.Collections.Generic;

namespace IAEGoogleDrie.Messaging.Commands
{
    public interface ICommandBus
    {
        void Send(Envelope<ICommand> command);
        void Send(IEnumerable<Envelope<ICommand>> commands);
    }
}