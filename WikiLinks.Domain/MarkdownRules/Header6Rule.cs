namespace WikiLinks.Domain.MarkdownRules
{
    public class Header6Rule : MarkdownRule, IMarkdownRule
    {
        private const string _MarkdownTag = "######";
        private const string _HtmlBeginTag = "<h6>";
        private const string _HtmlEndTag = "</h6>";

        public Header6Rule() : base(_MarkdownTag, _HtmlBeginTag, _HtmlEndTag, TagStyle.Both, true) { }
    }
}
