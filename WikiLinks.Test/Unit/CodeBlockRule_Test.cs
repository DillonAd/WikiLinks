using System.Collections.Generic;
using Moq;
using WikiLinks.Domain.MarkdownRules;
using Xunit;

namespace WikiLinks.Test
{
    public class CodeBlockRule_Test
    {
        [Theory]
        [InlineData("hello `world`", "hello <code>world</code>")]
        [InlineData("`hello world`", "<code>hello world</code>")]
        [InlineData("hello world", "hello world")]
        [InlineData("`hello` `world", "<code>hello</code> `world")]
        public void SingleLine(string input, string expected)   
        {
            //Assemble
            var cr = new CodeRule();

            //Act
            var result = cr.Parse(input);

            //Assert
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> MultilineInput =>
            new []
            {
                new object[] { "hello `world`", "hello <code>world</code>" },
                new object[] { "", "" }
            };

        [Theory]
        [MemberData(nameof(MultilineInput))]
        public void MultiLine(string input, string expected)   
        {
            //Assemble
            var cr = new CodeRule();

            //Act
            var result = cr.Parse(input);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}