using Microsoft.AspNetCore.Builder;

namespace LaRecipe;

public static class DocumentationExtensions
{
    public static void UseDocumentation(this IApplicationBuilder app) => app.UseMiddleware<DocumentationMiddleware>();
}
