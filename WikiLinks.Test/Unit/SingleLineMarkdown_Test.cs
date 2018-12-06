using System;
using System.Collections.Generic;
using WikiLinks.Domain;
using WikiLinks.Domain.MarkdownRules;
using Xunit;

namespace WikiLinks.Test.Unit
{
    public class SingleLineMarkdown_Test
    {
        [Theory]
        [Trait("Category", "unit")]
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
        [Trait("Category", "unit")]
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
        [Trait("Category", "unit")]
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
        [Trait("Category", "unit")]
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
        [Trait("Category", "unit")]
        [InlineData("###### hello ###### world", "<h6>hello</h6> world")]
        [InlineData("###### hello world", "<h6>hello world</h6>")]
        [InlineData(" ###### hello world", " <h6>hello world</h6>")]
        public void ParseHeader6(string initial, string expected)
        {
            var hr = new Header6Rule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "unit")]
        [InlineData("##### hello ##### world", "<h5>hello</h5> world")]
        [InlineData("##### hello world", "<h5>hello world</h5>")]
        [InlineData(" ##### hello world", " <h5>hello world</h5>")]
        public void ParseHeader5(string initial, string expected)
        {
            var hr = new Header5Rule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "unit")]
        [InlineData("#### hello #### world", "<h4>hello</h4> world")]
        [InlineData("#### hello world", "<h4>hello world</h4>")]
        [InlineData(" #### hello world", " <h4>hello world</h4>")]
        public void ParseHeader4(string initial, string expected)
        {
            var hr = new Header4Rule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "unit")]
        [InlineData("### hello ### world", "<h3>hello</h3> world")]
        [InlineData("### hello world", "<h3>hello world</h3>")]
        [InlineData(" ### hello world", " <h3>hello world</h3>")]
        public void ParseHeader3(string initial, string expected)
        {
            var hr = new Header3Rule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "unit")]
        [InlineData("## hello ## world", "<h2>hello</h2> world")]
        [InlineData("## hello world", "<h2>hello world</h2>")]
        [InlineData(" ## hello world", " <h2>hello world</h2>")]
        public void ParseHeader2(string initial, string expected)
        {
            var hr = new Header2Rule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "unit")]
        [InlineData("# hello # world", "<h1>hello</h1> world")]
        [InlineData("# hello world", "<h1>hello world</h1>")]
        [InlineData(" # hello world", " <h1>hello world</h1>")]
        public void ParseHeader1(string initial, string expected)
        {
            var hr = new Header1Rule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "unit")]
        [InlineData("`hello` world", "<code><pre>hello</pre></code> world")]
        [InlineData("`hello world`", "<code><pre>hello world</pre></code>")]
        [InlineData("hello `world`", "hello <code><pre>world</pre></code>")]
        [InlineData("` hello ` world", "<code><pre> hello </pre></code> world")]
        [InlineData("`hello ` world", "<code><pre>hello </pre></code> world")]
        public void ParseCodeLine(string initial, string expected)
        {
            var hr = new CodeRule();
            var result = hr.Parse(initial);
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "integration")]
        [InlineData("**hello world")]
        [InlineData("hello _world")]
        public void Parse_UnmatchedTags(string inital)
        {
            var rules = GetRules();
            var md = new Markdown(rules);
            var result = md.Parse(inital);

            Assert.Equal(inital + Environment.NewLine, result);
        }

        [Theory]
        [Trait("Category", "integration")]
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
                new Header1Rule(),
                new CodeRule()
            };
        }
    }
}
