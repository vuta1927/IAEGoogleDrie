﻿using IAEGoogleDrie.Domain.Entities;

namespace IAEGoogleDrie.Data.Uow
{
    /// <summary>
    /// Standard filter
    /// </summary>
    public class DataFilters
    {
        /// <summary>
        /// "SoftDelete".
        /// Soft delete filter.
        /// Prevents getting deleted data from database.
        /// See <see cref="ISoftDelete"/> interface.
        /// </summary>
        public const string SoftDelete = "SoftDelete";
    }
}