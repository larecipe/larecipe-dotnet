using LaRecipe.Application.Interfaces;
using LaRecipe.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LaRecipe.Application.Extensions;

public static class DependencyInjectionApplicationExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services) =>
        services
            .AddTransient<IDocumentationService, DocumentationService>();
}