using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IAEGoogleDrie.Helpers.Extensions;

namespace IAEGoogleDrie.Reflection
{
    public class AssemblyFinder : IAssemblyFinder
    {
        public List<Assembly> GetAllAssemblies()
        {
            return AppDomain.CurrentDomain.GetExcutingAssembiles().ToList();
        }
    }
}