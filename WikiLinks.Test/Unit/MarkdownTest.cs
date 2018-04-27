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
      var result = br.ParseRule(initial);
      Assert.Equal(expected, result);
    }
  }
}
