using Markdig.Extensions.AutoIdentifiers;

namespace LaRecipe.Core.Extensions.TableOfContents;

/// <summary>
/// Delegate for handle custom heading id generate.
/// </summary>
/// <param name="level">The level of current heading, usually be count of char <strong>'#'</strong></param>
/// <param name="content">The content of current heading.</param>
/// <param name="id">Not null if already defined id in markdown strings (e.g. <em># title {#<strong>id</strong>}</em>)</param>
/// <returns></returns>
public delegate string GenerateHeadingId(int level, string content, string? id);

/// <summary>
/// Options for CustomAutoIdExtension
/// </summary>
public class CustomAutoIdOptions
{
    /// <summary>
    /// Options for generate heading id
    /// </summary>
    public AutoIdentifierOptions Options { get; set; } = AutoIdentifierOptions.Default;

    /// <summary>
    /// Heading id generator.<br/>
    /// Notice: If already defined id in markdown strings (e.g. <em># title {#<strong>id</strong>}</em>), will pass by the <strong>id</strong> parameter .<br/>
    /// When set this with a <strong>not null</strong> value, the <see cref="Options"/> will be <strong>Ignored</strong>.<br/>
    /// </summary>
    public GenerateHeadingId? HeadingIdGenerator { get; set; }
}