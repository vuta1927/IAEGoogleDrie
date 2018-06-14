using System;
using System.Collections.Generic;

namespace IAEGoogleDrie.Configuration
{
    public interface IValidationConfiguration : IConfigurator
    {
        List<Type> IgnoredTypes { get; }
    }
}