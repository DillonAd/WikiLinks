namespace WikiLinks.Domain.MarkdownRules
{
    public class ItalicRule : SingleLineMarkdownRule
    {
        private const string _MarkdownTag = "_";
        private const string _HtmlBeginTag = "<i>";
        private const string _HtmlEndTag = "</i>";

        public ItalicRule() : base(_MarkdownTag, _HtmlBeginTag, _HtmlEndTag) { }
    }
}
