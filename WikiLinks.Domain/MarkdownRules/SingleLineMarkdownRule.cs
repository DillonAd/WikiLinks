using System;
using System.Text;

namespace WikiLinks.Domain.MarkdownRules
{
    public abstract class SingleLineMarkdownRule : IMarkdownRule
    {
        protected string MarkdownTag { get; }
        protected string HtmlBeginTag => _htmlBeginTag;
        protected string HtmlEndTag => _htmlEndTag;
        protected TagStyle TagStyle { get; }
        protected bool RequireSpace { get; } 

        private readonly string _htmlBeginTag;
        private readonly string _htmlEndTag;

        protected internal SingleLineMarkdownRule(string markdownTag, string htmlBeginTag, string htmlEndTag, TagStyle tagStyle = TagStyle.Matching, bool requireSpace = false)
        {
            MarkdownTag = markdownTag;
            _htmlBeginTag = htmlBeginTag;
            _htmlEndTag = htmlEndTag;
            TagStyle = tagStyle;
            RequireSpace = requireSpace;
        }

        public string Parse(string line)
        {
            var content = line;

            if(TagStyle == TagStyle.Matching || TagStyle == TagStyle.Both)
            {
                while (HasMatchingTags(ref content))
                {
                    content = ReplaceTag(content, HtmlBeginTag, HtmlEndTag, MarkdownTag);
                }
            }

            if(TagStyle == TagStyle.Single || TagStyle == TagStyle.Both)
            {
                if(content.TrimStart().StartsWith(MarkdownTag))
                {
                    content = ReplaceTag(content, HtmlBeginTag, HtmlEndTag, MarkdownTag);
                }
            }
        
            return content;
        }

        private bool HasMatchingTags(ref string content)
        {
            var beginTagIndex = content.IndexOf(MarkdownTag);

            if (beginTagIndex < 0)
            {
                return false;
            }

            var endTagIndex = content.IndexOf(MarkdownTag, beginTagIndex + MarkdownTag.Length);
            
            return beginTagIndex >= 0 &&
                   endTagIndex > beginTagIndex &&
                   beginTagIndex != endTagIndex;
        }

        private string ReplaceTag(string content, string replacementBeginTag, string replacementEndTag, string markdownTag)
        {
            var sb = new StringBuilder();

            int tagBeginIndex = content.IndexOf(markdownTag);
            int tagEndIndex = tagBeginIndex + markdownTag.Length;

            if(RequireSpace)
            {
                tagEndIndex++;
            }

            sb.Append(content.Substring(0, tagBeginIndex));
            sb.Append(replacementBeginTag);

            var endTagBeginIndex = content.IndexOf(markdownTag, tagEndIndex);
            var endTagEndIndex = endTagBeginIndex + markdownTag.Length;

            if(endTagBeginIndex > 0 && endTagEndIndex > 0)
            {
                var middleLength = endTagBeginIndex - tagEndIndex;
                
                if(RequireSpace)
                {
                    middleLength--;
                }

                sb.Append(content.Substring(tagEndIndex, middleLength));
                sb.Append(replacementEndTag);
                sb.Append(content.Substring(endTagEndIndex));
            }
            else
            {
                sb.Append(content.Substring(tagEndIndex, content.Length - tagEndIndex));
                sb.Append(HtmlEndTag);
            }

            return sb.ToString();
        }
    }
}
