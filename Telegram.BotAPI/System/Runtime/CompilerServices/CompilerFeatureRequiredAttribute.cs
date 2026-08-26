namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
#pragma warning disable CS9113 // Параметр не прочитан.
public sealed class CompilerFeatureRequiredAttribute(string featureName) : Attribute
#pragma warning restore CS9113 // Параметр не прочитан.
{
    //
}
