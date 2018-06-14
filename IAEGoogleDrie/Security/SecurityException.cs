﻿using System;
using System.Runtime.Serialization;

namespace IAEGoogleDrie.Security
{
    [Serializable]
    public class SecurityException : AppException
    {
        public SecurityException(string message) 
            : base(message) { }

        public SecurityException(string message, Exception innerException) 
            : base(message, innerException) { }

        protected SecurityException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }

    }
}