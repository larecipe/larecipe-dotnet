using FluentAssertions;
using LaRecipe.Application.Extensions;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace LaRecipe.Application.Tests.Extensions;

public class PathStringExtensionsTests
{
    [Theory]
    [InlineData("", false)]
    [InlineData("/", false)]
    [InlineData("/docs", false)]
    [InlineData("/docs/overview", false)]
    [InlineData("/docs/images/image", false)]
    [InlineData("/32rt34", false)]
    [InlineData("/3$2\\3232", false)]
    [InlineData("/docs/images/image.png", true)]
    [InlineData("/docs/app.css", true)]
    [InlineData("/app.js", true)]
    [InlineData("/docs/file.something", true)]
    [InlineData("/docs/some-file.something", true)]
    public void IsDocumentationAssets_Called_ShouldReturnCorrectValue(string path, bool expected)
    {
        new PathString(path).IsDocumentationAssets().Should().Be(expected);
    }
}