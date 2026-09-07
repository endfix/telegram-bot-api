using System.Reflection;
using System.Xml.Linq;
using FluentAssertions;
using Xunit;

namespace Endfix.Telegram.BotAPI.Tests;

public sealed class PublicApiDocumentationTests
{
    private static readonly string DocumentationPath = Path.Combine(
        AppContext.BaseDirectory,
        "Endfix.Telegram.BotAPI.xml");

    [Fact]
    public void PublicMethodsWithArguments_DocumentTheirParameters()
    {
        var document = XDocument.Load(DocumentationPath);

        var undocumentedMembers = document
            .Descendants("member")
            .Where(member =>
            {
                var name = (string?)member.Attribute("name");
                return name?.StartsWith("M:", StringComparison.Ordinal) == true
                    && name.Contains('(')
                    && !member.Elements("param").Any();
            })
            .Select(member => (string)member.Attribute("name")!)
            .ToArray();

        undocumentedMembers.Should().BeEmpty(
            "CS1573 only detects missing parameter documentation when at least one param tag exists");
    }

    [Fact]
    public void PublicDelegates_DocumentAllParameters()
    {
        var document = XDocument.Load(DocumentationPath);
        var members = document.Descendants("member").ToDictionary(
            member => (string)member.Attribute("name")!,
            StringComparer.Ordinal);

        var undocumentedDelegates = typeof(IBotApiClient).Assembly
            .GetExportedTypes()
            .Where(type => typeof(MulticastDelegate).IsAssignableFrom(type.BaseType))
            .Where(type =>
            {
                var memberName = $"T:{type.FullName!.Replace('+', '.')}";
                return !members.TryGetValue(memberName, out var member)
                    || member.Elements("param").Count()
                        != type.GetMethod("Invoke", BindingFlags.Public | BindingFlags.Instance)!
                            .GetParameters().Length;
            })
            .Select(type => type.FullName)
            .ToArray();

        undocumentedDelegates.Should().BeEmpty();
    }
}
