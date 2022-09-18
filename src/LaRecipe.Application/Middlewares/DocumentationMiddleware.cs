using System.Text;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using LaRecipe.Application.Extensions;
using LaRecipe.Application.Interfaces;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

namespace LaRecipe.Application.Middlewares;

public class DocumentationMiddleware
{
    private const string EmbeddedFileNamespace = "LaRecipe.Application";
    private const string LandingPath = "overview";

    private readonly StaticFileMiddleware _staticFileMiddleware;
    private readonly IDocumentationService _documentationService;

    public DocumentationMiddleware(
        RequestDelegate next, 
        IWebHostEnvironment hostingEnv,
        IDocumentationService documentationService,
        ILoggerFactory loggerFactory)
    {
        _staticFileMiddleware = CreateStaticFileMiddleware(next, hostingEnv, loggerFactory);
        _documentationService = documentationService;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var httpMethod = httpContext.Request.Method;
        var path = httpContext.Request.Path;

        if (httpMethod == HttpMethod.Get.ToString() && path.IsDocumentationRoot())
        {
            var relativeIndexUrl = path.ResolveRelativeUrl(LandingPath);
            RedirectToLandingDocumentation(httpContext.Response, relativeIndexUrl);
            return;
        }
        
        if (httpMethod == HttpMethod.Get.ToString() && path.IsDocumentationUrl())
        {
            await RespondWithIndexHtml(httpContext.Response, httpContext.Request);
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
    
    private static void RedirectToLandingDocumentation(HttpResponse response, string location)
    {
        response.StatusCode = 301;
        response.Headers["Location"] = location;
    }

    private async Task RespondWithIndexHtml(HttpResponse response, HttpRequest httpRequest)
    {
        response.StatusCode = 200;
        response.ContentType = "text/html;charset=utf-8";
        var result = await _documentationService.Get(httpRequest);
        await response.WriteAsync(result, Encoding.UTF8);
    }
}
