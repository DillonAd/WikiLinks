using WikiLinks.Domain.MarkdownRules;
using Xunit;

namespace WikiLinks.Test.Unit
{
    public class MarkdownTest
    {
        [Theory]
        [InlineData("hello **world**", "hello <b>world</b>")]
        [InlineData("hello **world **", "hello <b>world </b>")]
        [InlineData("hello ** world**", "hello <b> world</b>")]
        [InlineData("hello ** world **", "hello <b> world </b>")]
        public void ParseBold_Single(string initial, string expected)
        {
            var br = new BoldRule();
            var result = br.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hello _world_", "hello <i>world</i>")]
        [InlineData("hello _world _", "hello <i>world </i>")]
        [InlineData("hello _ world_", "hello <i> world</i>")]
        [InlineData("hello _ world _", "hello <i> world </i>")]
        public void ParseItalic(string initial, string expected)
        {
            var ir = new ItalicRule();
            var result = ir.Parse(initial);
            Assert.Equal(expected, result);
        }
    }
}
