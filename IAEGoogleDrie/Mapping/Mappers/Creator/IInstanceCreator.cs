using System.Reflection.Emit;
using IAEGoogleDrie.Mapping.Runtime;

namespace IAEGoogleDrie.Mapping.Mappers.Creator
{
    internal interface IInstanceCreator<TTarget>
    {
        void Compile(ModuleBuilder builder);

        void Emit(CompilationContext context);
    }
}
