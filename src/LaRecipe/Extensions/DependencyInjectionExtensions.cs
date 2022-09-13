using LaRecipe.Application.Extensions;
using LaRecipe.Application.Middlewares;
using LaRecipe.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LaRecipe.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddLaRecipe(this IServiceCollection services) =>
        services.AddApplicationLayer()
                .AddCoreLayer();
    
    public static IApplicationBuilder UseLaRecipe(this IApplicationBuilder app)
    {
        app.UseWhen(context => context.Request.Path.StartsWithSegments("/docs"),
            appBuilder => appBuilder.UseMiddleware<DocumentationMiddleware>());
        
        return app;
    }
}