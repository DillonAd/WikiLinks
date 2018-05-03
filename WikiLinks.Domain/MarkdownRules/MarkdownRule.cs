namespace WikiLinks.Domain.MarkdownRules
{
    public abstract class MarkdownRule
    {
        protected string MarkdownTag { get; }
        protected string HtmlBeginTag { get; }
        protected string HtmlEndTag { get; }
        protected bool IsMarkdownTagPair { get; }

        protected internal MarkdownRule(string markdownTag, string htmlBeginTag, string htmlEndTag, bool isMarkdownTagPair = false)
        {
            MarkdownTag = markdownTag;
            HtmlBeginTag = htmlBeginTag;
            HtmlEndTag = htmlEndTag;
            IsMarkdownTagPair = isMarkdownTagPair;
        }

        public string Parse(string content)
        {
            string inProgressContent;
            string newContent = content;

            foreach (var line in content.Split('\n'))
            {
                while (HasMatchingTags(newContent))
                {
                    inProgressContent = ReplaceTag(newContent, HtmlBeginTag);
                    inProgressContent = ReplaceTag(inProgressContent, HtmlEndTag);

                    newContent = inProgressContent;
                }
            }

            return newContent;
        }

        private bool HasMatchingTags(string content)
        {
            var beginTagIndex = content.IndexOf(MarkdownTag);

            if (beginTagIndex < 0)
            {
                return false;
            }

            var endTagIndex = content.IndexOf(MarkdownTag, beginTagIndex + MarkdownTag.Length);
            
            return beginTagIndex >= 0
                    && endTagIndex > beginTagIndex
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
