namespace WikiLinks.Domain.MarkdownRules
{
    public class Header4Rule : SingleLineMarkdownRule
    {
        private const string _MarkdownTag = "####";
        private const string _HtmlBeginTag = "<h4>";
        private const string _HtmlEndTag = "</h4>";

        public Header4Rule() : base(_MarkdownTag, _HtmlBeginTag, _HtmlEndTag, TagStyle.Both, true) { }
    }
}
