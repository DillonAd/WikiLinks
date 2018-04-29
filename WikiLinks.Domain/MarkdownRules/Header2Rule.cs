namespace WikiLinks.Domain.MarkdownRules
{
    public class Header2Rule : MarkdownRule, IMarkdownRule
    {
        private const string _MarkdownTag = "##";
        private const string _HtmlBeginTag = "<h2>";
        private const string _HtmlEndTag = "</h2>";

        public Header2Rule() : base(_MarkdownTag, _HtmlBeginTag, _HtmlEndTag) { }
    }
}
