using Markdig.Parsers;
using Markdig.Syntax;

namespace LaRecipe.Core.Extensions.TableOfContents;

public class TocBlock : HeadingBlock
{
    public TocBlock(BlockParser parser) : base(parser)
    {
        ProcessInlines = true;
    }
}