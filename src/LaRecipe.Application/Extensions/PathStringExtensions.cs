using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace LaRecipe.Application.Extensions;

public static class PathStringExtensions
{
    public static bool IsDocumentationRoot(this PathString pathString) =>
        pathString.Value != null && Regex.IsMatch(pathString.Value, $"^/?docs/?$",  RegexOptions.IgnoreCase);

    public static bool IsDocumentationUrl(this PathString pathString) =>
        pathString.Value != null && pathString.Value.StartsWith("/docs/") && ! pathString.IsDocumentationAssets(); 
    
    public static bool IsDocumentationAssets(this PathString pathString) =>
        pathString.Value != null && (pathString.Value.StartsWith("/docs/app.css") || pathString.Value.StartsWith("/docs/app.js"));

    public static string ResolveRelativeUrl(this PathString pathString, string url) => 
        string.IsNullOrEmpty(pathString) || ! pathString.HasValue || pathString.Value.EndsWith("/")
            ? url
            : $"{pathString.Value.Split('/').Last()}/{url}";
}