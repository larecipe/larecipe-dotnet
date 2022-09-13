using Microsoft.AspNetCore.Builder;

namespace LaRecipe;

public static class DocumentationExtensions
{
    public static IApplicationBuilder UseLaRecipe(this IApplicationBuilder app)
    {
        app.UseWhen(context => context.Request.Path.StartsWithSegments("/docs"),
            appBuilder => appBuilder.UseMiddleware<DocumentationMiddleware>());
        
        return app;
    }
}
