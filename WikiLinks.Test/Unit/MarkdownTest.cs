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
        [InlineData("**hello** **world**", "<b>hello</b> <b>world</b>")]
        [InlineData("**hello ** **world **", "<b>hello </b> <b>world </b>")]
        [InlineData("** hello** ** world**", "<b> hello</b> <b> world</b>")]
        [InlineData("** hello ** ** world **", "<b> hello </b> <b> world </b>")]
        public void ParseBold_Multiple(string initial, string expected)
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
        public void ParseItalic_Single(string initial, string expected)
        {
            var ir = new ItalicRule();
            var result = ir.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("_hello_ _world_", "<i>hello</i> <i>world</i>")]
        [InlineData("_hello _ _world _", "<i>hello </i> <i>world </i>")]
        [InlineData("_ hello_ _ world_", "<i> hello</i> <i> world</i>")]
        [InlineData("_ hello _ _ world _", "<i> hello </i> <i> world </i>")]
        public void ParseItalic_Multiple(string initial, string expected)
        {
            var ir = new ItalicRule();
            var result = ir.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hello ######world######", "hello <h6>world</h6>")]
        [InlineData("hello ######world ######", "hello <h6>world </h6>")]
        [InlineData("hello ###### world######", "hello <h6> world</h6>")]
        [InlineData("hello ###### world ######", "hello <h6> world </h6>")]
        public void ParseHeader6(string initial, string expected)
        {
            var hr = new Header6Rule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }
    }
}
