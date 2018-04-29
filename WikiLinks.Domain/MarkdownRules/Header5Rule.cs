namespace WikiLinks.Domain.MarkdownRules
{
    public class Header5Rule : MarkdownRule, IMarkdownRule
    {
        private const string _MarkdownTag = "#####";
        private const string _HtmlBeginTag = "<h5>";
        private const string _HtmlEndTag = "</h5>";

        public Header5Rule() : base(_MarkdownTag, _HtmlBeginTag, _HtmlEndTag) { }
    }
}
