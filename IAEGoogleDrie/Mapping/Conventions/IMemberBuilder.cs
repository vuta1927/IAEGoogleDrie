using IAEGoogleDrie.Mapping.Runtime;

namespace IAEGoogleDrie.Mapping.Conventions
{
    internal interface IMemberBuilder
    {
        void EmitGetter(CompilationContext context);

        void EmitSetter(CompilationContext context);
    }
}
