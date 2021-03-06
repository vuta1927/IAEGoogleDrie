﻿using Microsoft.Extensions.DependencyInjection;

namespace IAEGoogleDrie.Dependency
{
    /// <summary>
    /// Dependency registrar interface
    /// </summary>
    public interface IRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="services">Service collection</param>
        void Register(IServiceCollection services);
    }
}