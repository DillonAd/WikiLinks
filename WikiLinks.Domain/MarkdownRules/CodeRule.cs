namespace WikiLinks.Domain.MarkdownRules
{
    public class CodeRule : SingleLineMarkdownRule
    {
        private const string _MarkdownTag = "`";
        private const string _HtmlBeginTag = "<code>";
        private const string _HtmlEndTag = "</code>";

        public CodeRule() : base(_MarkdownTag, _HtmlBeginTag, _HtmlEndTag) { }
    }
}