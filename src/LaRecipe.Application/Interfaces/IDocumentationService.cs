using Microsoft.AspNetCore.Http;

namespace LaRecipe.Application.Interfaces;

public interface IDocumentationService
{
    public Task<string> Get(HttpRequest httpRequest);
}