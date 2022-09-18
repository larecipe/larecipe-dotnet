using System.Reflection;
using System.Text;
using LaRecipe.Application.Extensions;
using LaRecipe.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LaRecipe.Application.Services;

public class DocumentationService: IDocumentationService
{
    private const string EmbeddedFileNamespace = "LaRecipe.Application";
    private const string EmbeddedIndexHtmlFile = $"{EmbeddedFileNamespace}.index.html";
    
    private readonly IDocumentationResolver _documentationResolver;
    
    public DocumentationService(IDocumentationResolver documentationResolver)
    {
        _documentationResolver = documentationResolver;
    }

    public async Task<string> Get(HttpRequest httpRequest)
    {
        using var reader = new StreamReader(GetIndexStream());
        var htmlBuilder = new StringBuilder(await reader.ReadToEndAsync());
        
        foreach (var entry in GetIndexArguments(httpRequest))
        {
            htmlBuilder.Replace(entry.Key, entry.Value);
        }

        return htmlBuilder.ToString();
    }
    
    private Func<Stream> GetIndexStream { get; } = () => Assembly.GetExecutingAssembly()
        .GetManifestResourceStream(EmbeddedIndexHtmlFile)!;

    private IDictionary<string, string> GetIndexArguments(HttpRequest httpRequest)
    {
        var (content, sidebar) = _documentationResolver.Resolve();
        
        return new Dictionary<string, string>
        {
            { "%(DocumentTitle)", "Documentation" },
            { "%(Content)",  content},
            { "%(Sidebar)",  sidebar},
            { "%(StyleLink)",  httpRequest.GetRelativeUrlForPath("docs/app.css") },
            { "%(ScriptLink)",  httpRequest.GetRelativeUrlForPath("docs/app.js") }
        };
    }
}