using IAEGoogleDrie.Dependency;
using Microsoft.Extensions.Primitives;

namespace IAEGoogleDrie.Caching
{
    public interface ISignal : ISingletonDependency
    {
        IChangeToken GetToken(string key);

        void SignalToken(string key);
    }
}
