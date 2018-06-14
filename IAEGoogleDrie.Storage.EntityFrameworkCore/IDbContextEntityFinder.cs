using System;
using System.Collections.Generic;
using IAEGoogleDrie.Domain.Entities;

namespace IAEGoogleDrie.Storage.EntityFrameworkCore
{
    public interface IDbContextEntityFinder
    {
        IEnumerable<EntityTypeInfo> GetEntityTypeInfos(Type dbContextType);
    }
}