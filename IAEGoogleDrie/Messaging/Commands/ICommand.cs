﻿using System;

namespace IAEGoogleDrie.Messaging.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// Gets the command identifier.
        /// </summary>
        Guid Id { get; }
    }
}