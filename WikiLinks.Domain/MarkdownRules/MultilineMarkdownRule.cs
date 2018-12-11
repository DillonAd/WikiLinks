using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WikiLinks.Domain.MarkdownRules
{
    public abstract class MultilineMarkdownRule
    {
        protected string MarkdownTag { get; }
        protected string HtmlBeginTag => _htmlBeginTag;
        protected string HtmlEndTag => _htmlEndTag;
        protected TagStyle TagStyle { get; }
        protected bool RequireSpace { get; } 

        private readonly string _htmlBeginTag;
        private readonly string _htmlEndTag;

        protected internal MultilineMarkdownRule(string markdownTag, string htmlBeginTag, string htmlEndTag, TagStyle tagStyle = TagStyle.Matching, bool requireSpace = false)
        {
            MarkdownTag = markdownTag;
            _htmlBeginTag = htmlBeginTag;
            _htmlEndTag = htmlEndTag;
            TagStyle = tagStyle;
            RequireSpace = requireSpace;
        }

        public string Parse(string input)
        {
            var tag = MarkdownTag + (RequireSpace ? " " : "");
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            
            var line = string.Empty;
            var result = new StringBuilder();

            for(int i = 0; i < lines.Length; i++)
            {
                if(TagStyle == TagStyle.Single)
                {
                    if(lines[i].StartsWith(tag))
                    {
                        if(i > 0 && lines[i - 1].StartsWith(tag))
                        {
                            result.Append(lines[i].Replace(tag, string.Empty));
                        }
                        else
                        {
                            result.Append(lines[i].Replace(tag, HtmlBeginTag));
                        }

                        if((i < lines.Length - 1 && !lines[i + 1].StartsWith(tag)) || i == lines.Length -1)
                        {
                            result.AppendLine(HtmlEndTag);       
                        }
                        else
                        {
                            result.AppendLine();
                        }
                    }
                    else
                    {
                        result.AppendLine(lines[i]);
                    }
                }
            }

            return result.ToString();
        }
    }
}