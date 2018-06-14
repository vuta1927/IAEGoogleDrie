using System.Reflection.Emit;

namespace IAEGoogleDrie.Mapping.Runtime
{
    internal interface IInvokerBuilder
    {
        void Compile(ModuleBuilder builder);

        void Emit(CompilationContext context);
    }
}
