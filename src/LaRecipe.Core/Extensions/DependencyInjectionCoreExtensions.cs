using LaRecipe.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LaRecipe.Core.Extensions;

public static class DependencyInjectionCoreExtensions
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services) =>
        services
            .AddTransient<IDocumentationResolver, DocumentationResolver>();
}