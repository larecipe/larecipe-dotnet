using System.Text;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;
using LaRecipe.Application.Interfaces;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

namespace LaRecipe.Application.Middlewares;

public class DocumentationMiddleware
{
    private const string EmbeddedFileNamespace = "LaRecipe.Application";
    private const string EmbeddedIndexHtmlFile = $"{EmbeddedFileNamespace}.index.html";

    private readonly StaticFileMiddleware _staticFileMiddleware;
    private readonly IDocumentationResolver _documentationResolver;

    public DocumentationMiddleware(
        RequestDelegate next,
        IWebHostEnvironment hostingEnv,
        IDocumentationResolver documentationResolver,
        ILoggerFactory loggerFactory)
    {
        _staticFileMiddleware = CreateStaticFileMiddleware(next, hostingEnv, loggerFactory);
        _documentationResolver = documentationResolver;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var httpMethod = httpContext.Request.Method;
        var path = httpContext.Request.Path.Value;

        if (path != null && httpMethod == "GET" && Regex.IsMatch(path, $"^/?docs/?$",  RegexOptions.IgnoreCase))
        {
            await RespondWithIndexHtml(httpContext.Response);
            return;
        }

        await _staticFileMiddleware.Invoke(httpContext);
    }

    private static StaticFileMiddleware CreateStaticFileMiddleware(RequestDelegate next, IWebHostEnvironment hostingEnv,
        ILoggerFactory loggerFactory)
    {
        var staticFileOptions = new StaticFileOptions
        {
            RequestPath = "/docs",
            FileProvider = new EmbeddedFileProvider(typeof(DocumentationMiddleware).GetTypeInfo().Assembly, EmbeddedFileNamespace),
        };

        return new StaticFileMiddleware(next, hostingEnv, Options.Create(staticFileOptions), loggerFactory);
    }

    private async Task RespondWithIndexHtml(HttpResponse response)
    {
        response.StatusCode = 200;
        response.ContentType = "text/html;charset=utf-8";

        var r = Assembly.GetExecutingAssembly();
        using var reader = new StreamReader(GetIndexStream());
        var htmlBuilder = new StringBuilder(await reader.ReadToEndAsync());
        foreach (var entry in GetIndexArguments())
        {
            htmlBuilder.Replace(entry.Key, entry.Value);
        }
        await response.WriteAsync(htmlBuilder.ToString(), Encoding.UTF8);
    }

    private Func<Stream> GetIndexStream { get; } = () => Assembly.GetExecutingAssembly()
        .GetManifestResourceStream(EmbeddedIndexHtmlFile)!;

    private IDictionary<string, string> GetIndexArguments() =>
        new Dictionary<string, string>
        {
            { "%(DocumentTitle)", "Documentation" },
            { "%(DocumentContent)", _documentationResolver.Resolve() },
        };
}
