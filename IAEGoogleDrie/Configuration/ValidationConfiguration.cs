﻿using System;
using System.Collections.Generic;

namespace IAEGoogleDrie.Configuration
{
    public class ValidationConfiguration : IValidationConfiguration
    {
        public ValidationConfiguration(IConfigure configure)
        {
            Configure = configure;
            IgnoredTypes = new List<Type>();
        }

        public IConfigure Configure { get; }
        public List<Type> IgnoredTypes { get; }
    }
}