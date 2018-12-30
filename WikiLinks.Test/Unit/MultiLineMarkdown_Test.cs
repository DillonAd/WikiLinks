using System;
using System.Collections.Generic;
using WikiLinks.Domain.MarkdownRules;
using Xunit;

namespace WikiLinks.Test.Unit
{
    public class MultiLineMarkdown_Test
    {

        public static IEnumerable<object[]> BlockquoteData =>
            new[] 
            {
                new object[] { $"> hello", $"<blockquote><pre>hello</pre></blockquote>{Environment.NewLine}" },
                new object[] { $"> hello{Environment.NewLine}> world", $"<blockquote><pre>hello{Environment.NewLine}world</pre></blockquote>{Environment.NewLine}" },
                new object[] { $"> hello{Environment.NewLine}> world{Environment.NewLine}> !", $"<blockquote><pre>hello{Environment.NewLine}world{Environment.NewLine}!</pre></blockquote>{Environment.NewLine}" },
                new object[] { $"> hello{Environment.NewLine}> world{Environment.NewLine}> !{Environment.NewLine}", $"<blockquote><pre>hello{Environment.NewLine}world{Environment.NewLine}!</pre></blockquote>{Environment.NewLine}{Environment.NewLine}" }
            };

        [Theory]
        [Trait("Category", "unit")]
        [MemberData(nameof(BlockquoteData))]
        public void ParseBlockquote(string input, string expected)
        {
            //Assemble
            var bqr = new BlockquoteRule();

            //Act
            var result = bqr.Parse(input);

            //Assert
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> MultilineInput =>
            new []
            {
                new object[] { "hello \n```\nworld\n```", "hello \n<pre><code>\nworld\n</code></pre>" },
                new object[] { "```\nhello\nworld\n```", "<pre><code>\nhello\nworld\n</code></pre>" },
                new object[] { "", "" },
                new object[] { "\n\n", "\n\n" }
            };

        [Theory]
        [MemberData(nameof(MultilineInput))]
        public void ParseCodeBlock(string input, string expected)   
        {
            //Assemble
            var cbr = new CodeBlockRule();

            //Act
            var result = cbr.Parse(input);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}