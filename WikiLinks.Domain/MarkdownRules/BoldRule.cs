namespace WikiLinks.Domain.MarkdownRules
{
    public class BoldRule : SingleLineMarkdownRule
    {
        private const string _MarkdownTag = "**";
        private const string _HtmlBeginTag = "<b>";
        private const string _HtmlEndTag = "</b>";

        public BoldRule() : base(_MarkdownTag, _HtmlBeginTag, _HtmlEndTag) { }
    }
}
