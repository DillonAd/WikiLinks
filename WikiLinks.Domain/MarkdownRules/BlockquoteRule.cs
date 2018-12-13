namespace WikiLinks.Domain.MarkdownRules
{
    public class BlockquoteRule : MultilineMarkdownRule
    {
        private const string _MarkdownTag = ">";
        private const string _HtmlBeginTag = "<blockquote><pre>";
        private const string _HtmlEndTag = "</pre></blockquote>";

        public BlockquoteRule() : base(_MarkdownTag, _HtmlBeginTag, _HtmlEndTag, TagStyle.Single, true) { }
    }
}