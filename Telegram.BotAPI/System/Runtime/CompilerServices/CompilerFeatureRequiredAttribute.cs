namespace System.Runtime.CompilerServices;

/// <summary>Indicates that a compiler feature is required to use the attributed program element.</summary>
/// <param name="featureName">Name of the required compiler feature.</param>
[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
#pragma warning disable CS9113 // Параметр не прочитан.
public sealed class CompilerFeatureRequiredAttribute(string featureName) : Attribute
#pragma warning restore CS9113 // Параметр не прочитан.
{
    //
}
