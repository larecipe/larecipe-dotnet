using Markdig;
using System.Text;
using LaRecipe.Application.Domain;
using LaRecipe.Application.Interfaces;

namespace LaRecipe.Core;

public class DocumentationResolver: IDocumentationResolver
{
    public DocumentationPage Resolve()
    {
        using var contentStreamReader = new StreamReader(@"Documentation/overview.md");
        using var sidebarStreamReader = new StreamReader(@"Documentation/index.md");
        
        var contentStringBuilder = new StringBuilder(contentStreamReader.ReadToEnd());
        var sidebarStringBuilder = new StringBuilder(sidebarStreamReader.ReadToEnd());
        
        var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseTableOfContent()
                .Build();
        
        var content = Markdown.ToHtml(contentStringBuilder.ToString(), pipeline);
        var sidebar =  Markdown.ToHtml(sidebarStringBuilder.ToString());
        
        return new DocumentationPage(content, sidebar);
    }
}
