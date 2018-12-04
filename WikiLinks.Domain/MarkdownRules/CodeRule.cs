namespace WikiLinks.Domain.MarkdownRules
{
    public class CodeRule : MarkdownRule
    {
        private const string _MarkdownTag = "`";
        private const string _HtmlBeginTag = "<code><pre>";
        private const string _HtmlEndTag = "</pre></code>";

        public CodeRule() : base(_MarkdownTag, _HtmlBeginTag, _HtmlEndTag) { }
    }
}