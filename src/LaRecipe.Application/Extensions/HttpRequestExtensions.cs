using Microsoft.AspNetCore.Http;

namespace LaRecipe.Application.Extensions;

public static class HttpRequestExtensions
{
    public static string GetRelativeUrlForPath(this HttpRequest httpRequest, string path) => 
        httpRequest.PathBase.HasValue ? $"{httpRequest.PathBase.Value}/{path}" : $"/{path}";
}