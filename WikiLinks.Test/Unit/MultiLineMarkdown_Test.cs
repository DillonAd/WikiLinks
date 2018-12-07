using WikiLinks.Domain.MarkdownRules;
using Xunit;

namespace WikiLinks.Test.Unit
{
    public class MultiLineMarkdown_Test
    {
        [Theory]
        [Trait("Category", "unit")]
        [InlineData("> hello", "<blockquote><pre>hello</pre></blockquote>")]
        [InlineData("> hello\n> world", "<blockquote><pre>hello\nworld</pre></blockquote>")]
        [InlineData("> hello\n> world\n> !", "<blockquote><pre>hello\nworld\n!</pre></blockquote>")]
        public void ParseBlockquote(string input, string expected)
        {
            //Assemble
            var bqr = new BlockquoteRule();

            //Act
            var result = bqr.Parse(input);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}