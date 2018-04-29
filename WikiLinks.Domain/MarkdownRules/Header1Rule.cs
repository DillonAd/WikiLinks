namespace WikiLinks.Domain.MarkdownRules
{
    public class Header1Rule : MarkdownRule, IMarkdownRule
    {
        private const string _MarkdownTag = "#";
        private const string _HtmlBeginTag = "<h1>";
        private const string _HtmlEndTag = "</h1>";

        public Header1Rule() : base(_MarkdownTag, _HtmlBeginTag, _HtmlEndTag) { }
    }
}
