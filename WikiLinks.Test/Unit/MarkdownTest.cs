using System;
using System.Collections.Generic;
using WikiLinks.Domain;
using WikiLinks.Domain.MarkdownRules;
using Xunit;

namespace WikiLinks.Test.Unit
{
    public class MarkdownTest
    {
        [Theory]
        [InlineData("hello **world**", "hello <b>world</b>\n")]
        [InlineData("hello **world **", "hello <b>world </b>\n")]
        [InlineData("hello ** world**", "hello <b> world</b>\n")]
        [InlineData("hello ** world **", "hello <b> world </b>\n")]
        public void ParseBold_Single(string initial, string expected)
        {
            var br = new BoldRule();
            var result = br.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("**hello** **world**", "<b>hello</b> <b>world</b>\n")]
        [InlineData("**hello ** **world **", "<b>hello </b> <b>world </b>\n")]
        [InlineData("** hello** ** world**", "<b> hello</b> <b> world</b>\n")]
        [InlineData("** hello ** ** world **", "<b> hello </b> <b> world </b>\n")]
        public void ParseBold_Multiple(string initial, string expected)
        {
            var br = new BoldRule();
            var result = br.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hello _world_", "hello <i>world</i>\n")]
        [InlineData("hello _world _", "hello <i>world </i>\n")]
        [InlineData("hello _ world_", "hello <i> world</i>\n")]
        [InlineData("hello _ world _", "hello <i> world </i>\n")]
        public void ParseItalic_Single(string initial, string expected)
        {
            var ir = new ItalicRule();
            var result = ir.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("_hello_ _world_", "<i>hello</i> <i>world</i>\n")]
        [InlineData("_hello _ _world _", "<i>hello </i> <i>world </i>\n")]
        [InlineData("_ hello_ _ world_", "<i> hello</i> <i> world</i>\n")]
        [InlineData("_ hello _ _ world _", "<i> hello </i> <i> world </i>\n")]
        public void ParseItalic_Multiple(string initial, string expected)
        {
            var ir = new ItalicRule();
            var result = ir.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("###### hello ###### world", "<h6>hello</h6> world\n")]
        [InlineData("###### hello world", "<h6>hello world</h6>\n")]
        [InlineData(" ###### hello world", " <h6>hello world</h6>\n")]
        public void ParseHeader6(string initial, string expected)
        {
            var hr = new Header6Rule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("##### hello ##### world", "<h5>hello</h5> world\n")]
        [InlineData("##### hello world", "<h5>hello world</h5>\n")]
        [InlineData(" ##### hello world", " <h5>hello world</h5>\n")]
        public void ParseHeader5(string initial, string expected)
        {
            var hr = new Header5Rule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("#### hello #### world", "<h4>hello</h4> world\n")]
        [InlineData("#### hello world", "<h4>hello world</h4>\n")]
        [InlineData(" #### hello world", " <h4>hello world</h4>\n")]
        public void ParseHeader4(string initial, string expected)
        {
            var hr = new Header4Rule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("### hello ### world", "<h3>hello</h3> world\n")]
        [InlineData("### hello world", "<h3>hello world</h3>\n")]
        [InlineData(" ### hello world", " <h3>hello world</h3>\n")]
        public void ParseHeader3(string initial, string expected)
        {
            var hr = new Header3Rule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("## hello ## world", "<h2>hello</h2> world\n")]
        [InlineData("## hello world", "<h2>hello world</h2>\n")]
        [InlineData(" ## hello world", " <h2>hello world</h2>\n")]
        public void ParseHeader2(string initial, string expected)
        {
            var hr = new Header2Rule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("# hello # world", "<h1>hello</h1> world\n")]
        [InlineData("# hello world", "<h1>hello world</h1>\n")]
        [InlineData(" # hello world", " <h1>hello world</h1>\n")]
        public void ParseHeader1(string initial, string expected)
        {
            var hr = new Header1Rule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory(Skip="Skipping until the algorithm can be refactored to not include a ridiculous amount of newlines")]
        [InlineData("**hello world")]
        [InlineData("hello _world")]
        public void Parse_UnmatchedTags(string inital)
        {
            var rules = GetRules();
            var md = new Markdown(rules);
            var result = md.Parse(inital);

            Assert.Equal(inital, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void Parse_NullOrWhiteSpace(string initial)
        {
            var rules = GetRules();
            var md = new Markdown(rules);
            var result = md.Parse(initial);

            Assert.Empty(result);
        }

        private List<IMarkdownRule> GetRules()
        {
            return new List<IMarkdownRule>()
            {
                new BoldRule(),
                new ItalicRule(),
                new Header6Rule(),
                new Header5Rule(),
                new Header4Rule(),
                new Header3Rule(),
                new Header2Rule(),
                new Header1Rule()
                
            };
        }
    }
}
