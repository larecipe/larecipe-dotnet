using Microsoft.AspNetCore.Http;

namespace LaRecipe.Application.Extensions;

public static class HttpRequestExtensions
{
    public static string GetRelativeUrlForPath(this HttpRequest httpRequest, string path)
    {
        var relativeUrl = httpRequest.PathBase.HasValue ? $"{httpRequest.PathBase.Value}/{path}" : $"/{path}"; 
        return $"{httpRequest.Scheme}://{httpRequest.Host.Value}{relativeUrl}";
    }
}