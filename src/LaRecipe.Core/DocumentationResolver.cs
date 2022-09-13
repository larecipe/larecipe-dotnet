using Markdig;
using System.Text;
using LaRecipe.Application.Interfaces;

namespace LaRecipe.Core;

public class DocumentationResolver: IDocumentationResolver
{
    public string Resolve()
    {
        using var reader = new StreamReader(@"Documentation/overview.md");
        var stringBuilder = new StringBuilder(reader.ReadToEnd());

        return Markdown.ToHtml(stringBuilder.ToString());
    }
}
