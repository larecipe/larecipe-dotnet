using Markdig;
using System.Text;
using LaRecipe.Application.Domain;
using LaRecipe.Application.Interfaces;
using LaRecipe.Core.Extensions.TableOfContents;

namespace LaRecipe.Core;

public class DocumentationResolver: IDocumentationResolver
{
    public DocumentationPage Resolve(GetDocumentationQuery getDocumentationQuery)
    {
        using var contentStreamReader = new StreamReader($@"Documentation/{getDocumentationQuery.Path}.md");
        using var sidebarStreamReader = new StreamReader(@"Documentation/index.md");
        
        var contentStringBuilder = new StringBuilder(contentStreamReader.ReadToEnd());
        var sidebarStringBuilder = new StringBuilder(sidebarStreamReader.ReadToEnd());
        
        var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseTableOfContent(opt =>
                {
                    opt.ContainerTag = "aside";
                    opt.ContainerClass = "table-of-contents-sidebar-wrapper";
                    opt.TocTag = "aside";
                    opt.TocClass = "table-of-contents-sidebar table-of-contents";
                    opt.ulClass = "table-of-contents";
                })
                .Build();
        
        var content = Markdown.ToHtml(contentStringBuilder.ToString(), pipeline);
        var sidebar =  Markdown.ToHtml(sidebarStringBuilder.ToString());
        
        return new DocumentationPage(content, sidebar);
    }
}
