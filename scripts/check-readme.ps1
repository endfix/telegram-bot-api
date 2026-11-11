<#
.SYNOPSIS
    Checks that README.md renders correctly on the nuget.org package page.

.DESCRIPTION
    README.md is packed into the NuGet package through <PackageReadmeFile>, and
    nuget.org renders that copy with raw HTML disabled and without repository
    context. Two things therefore break only on the package page:

      * raw HTML tags are escaped, so <p align="center"> shows up as literal text;
      * relative links such as CHANGELOG.md resolve against nuget.org and 404.

    Both are easy to introduce and invisible in GitHub's renderer, so this
    script fails the build instead. Code fences and inline code spans are
    ignored, because their content is meant to be shown verbatim.

    Run locally with:

        pwsh ./scripts/check-readme.ps1

.PARAMETER Path
    README file to check. Defaults to the repository root README.md.
#>
[CmdletBinding()]
param(
    [string]$Path
)

$ErrorActionPreference = 'Stop'

if ([string]::IsNullOrWhiteSpace($Path)) {
    $scriptRoot = if ($PSScriptRoot) { $PSScriptRoot } else { Split-Path -Parent $MyInvocation.MyCommand.Path }
    $Path = Join-Path (Split-Path -Parent $scriptRoot) 'README.md'
}

if (-not (Test-Path -LiteralPath $Path)) {
    throw "README file not found: $Path"
}

$lines = @(Get-Content -LiteralPath $Path -Encoding UTF8)
$problems = [System.Collections.Generic.List[string]]::new()
$inFence = $false
$fenceMarker = $null

for ($index = 0; $index -lt $lines.Count; $index++) {
    $line = $lines[$index]
    $number = $index + 1

    if ($line -match '^\s{0,3}(?<marker>```|~~~)') {
        $marker = $Matches['marker']

        if (-not $inFence) {
            $inFence = $true
            $fenceMarker = $marker
        }
        elseif ($marker -eq $fenceMarker) {
            $inFence = $false
            $fenceMarker = $null
        }

        continue
    }

    if ($inFence) {
        continue
    }

    # Strip inline code spans so `<token>` placeholders are not treated as HTML.
    $text = [regex]::Replace($line, '`[^`]*`', '')

    foreach ($match in [regex]::Matches($text, '<[A-Za-z/!][^<>]*>')) {
        $problems.Add("line ${number}: raw HTML '$($match.Value)' is escaped by nuget.org; use Markdown instead")
    }

    foreach ($match in [regex]::Matches($text, '!?\[[^\]]*\]\(\s*(?<target>[^)\s]+)(?:\s+"[^"]*")?\s*\)')) {
        $target = $match.Groups['target'].Value

        if ($target -match '^(?:https?://|mailto:|#)') {
            continue
        }

        $problems.Add("line ${number}: relative link '$target' does not resolve on nuget.org; use an absolute URL")
    }
}

if ($inFence) {
    $problems.Add("unterminated '$fenceMarker' code fence; the rest of the file was not checked")
}

if ($problems.Count -gt 0) {
    foreach ($problem in $problems) {
        Write-Host "README: $problem"
    }

    throw "README.md is not NuGet-safe: $($problems.Count) problem(s) found."
}

Write-Host "README.md is NuGet-safe: no raw HTML and no relative links outside code."
