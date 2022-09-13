using Markdig;
using System.Text;

namespace LaRecipe;

public class DocumentationResolver: IDocumentationResolver
{
    public string Resolve()
    {
        using var reader = new StreamReader(@"../../docs/overview.md");
        var stringBuilder = new StringBuilder(reader.ReadToEnd());

        return Markdown.ToHtml(stringBuilder.ToString());
    }
}
