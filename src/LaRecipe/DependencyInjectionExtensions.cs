using Microsoft.Extensions.DependencyInjection;

namespace LaRecipe;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddLaRecipe(this IServiceCollection services) =>
        services
            .AddTransient<IDocumentationResolver, DocumentationResolver>();
}