namespace WikiLinks.Domain.MarkdownRules
{
    public class Header3Rule : SingleLineMarkdownRule
    {
        private const string _MarkdownTag = "###";
        private const string _HtmlBeginTag = "<h3>";
        private const string _HtmlEndTag = "</h3>";

        public Header3Rule() : base(_MarkdownTag, _HtmlBeginTag, _HtmlEndTag, TagStyle.Both, true) { }
    }
}
