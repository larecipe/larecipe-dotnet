using LaRecipe.Application.Domain;

namespace LaRecipe.Application.Interfaces;

public interface IDocumentationResolver
{
    DocumentationPage Resolve(GetDocumentationQuery getDocumentationQuery);
}