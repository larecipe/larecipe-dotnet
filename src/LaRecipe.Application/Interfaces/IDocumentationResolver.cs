using LaRecipe.Application.Domain;

namespace LaRecipe.Application.Interfaces;

public interface IDocumentationResolver
{
    DocumentationPage Resolve();
}