namespace System.Runtime.CompilerServices;

#if NETSTANDARD2_0
/// <summary>Indicates that a type or member participates in the required-member feature.</summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
internal sealed class RequiredMemberAttribute : Attribute
{
    //
}
#endif
