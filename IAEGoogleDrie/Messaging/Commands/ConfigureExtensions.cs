using System;
using IAEGoogleDrie.Configuration;
using IAEGoogleDrie.Helpers.Exception;

namespace IAEGoogleDrie.Messaging.Commands
{
    public static partial class ConfigureExtensions
    {
        public static IConfigure Message(this IConfigure configure, Action<IMessageConfiguration> configAction)
        {
            Throw.IfArgumentNull(configure, nameof(configure));
            IMessageConfiguration messageConfiguration = new MessageConfiguration(configure);
            configAction(messageConfiguration);
//            configure.RegisterServices(s => s.AddSingleton(messageConfiguration));
            return configure;
        }
    }
}