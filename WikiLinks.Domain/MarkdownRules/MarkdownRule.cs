namespace WikiLinks.Domain.MarkdownRules
{
    public abstract class MarkdownRule
    {
        protected string MarkdownTag { get; }
        protected string HtmlBeginTag { get; }
        protected string HtmlEndTag { get; }

        private readonly string _EscapedMarkdownTag;

        protected internal MarkdownRule(string markdownTag, string htmlBeginTag, string htmlEndTag)
        {
            MarkdownTag = markdownTag;
            HtmlBeginTag = htmlBeginTag;
            HtmlEndTag = htmlEndTag;
        }

        public string Parse(string content)
        {
            string inProgressContent;
            string newContent = content;

            while (HasMatchingTags(newContent))
            {
                inProgressContent = ReplaceTag(newContent, HtmlBeginTag);
                inProgressContent = ReplaceTag(inProgressContent, HtmlEndTag);

                newContent = inProgressContent;
            }

            return newContent;
        }

        private bool HasMatchingTags(string content)
        {
            var beginTagIndex = content.IndexOf(MarkdownTag);
            var nextSearchIndex = beginTagIndex + 1 <= content.Length ? beginTagIndex + 1 : beginTagIndex;

            if (beginTagIndex < 0 || nextSearchIndex == beginTagIndex)
            {
                return false;
            }

            var endTagIndex = content.IndexOf(MarkdownTag, nextSearchIndex);

            return beginTagIndex >= 0
                    && endTagIndex >= 0
                    && beginTagIndex != endTagIndex;
        }

        private string ReplaceTag(string content, string replacementTag)
        {
            int tagBeginIndex = content.IndexOf(MarkdownTag);
            int tagEndIndex = tagBeginIndex + MarkdownTag.Length;

            return content.Substring(0, tagBeginIndex) +
                    replacementTag +
                    content.Substring(tagEndIndex);
        }
    }
}
