namespace System.Runtime.CompilerServices;

/// <summary>Indicates that a type or member participates in the required-member feature.</summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public sealed class RequiredMemberAttribute : Attribute
{
    //
}
