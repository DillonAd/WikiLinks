using System;
using System.Text;

namespace WikiLinks.Domain.MarkdownRules
{
    public class CodeBlockRule : MultilineMarkdownRule
    {
        private const string _MarkdownTag = "```";
        private const string _HtmlBeginTag = "<pre><code>";
        private const string _HtmlEndTag = "</code></pre>";

        public CodeBlockRule() : base(_MarkdownTag, _HtmlBeginTag, _HtmlEndTag, TagStyle.Matching) { }

        public override string Parse(string content)
        {
            const int baseIndex = -1;
            
            var openTagIndex = baseIndex;
            var closeTagIndex = baseIndex;

            var lines = content.Split(new [] { Environment.NewLine }, StringSplitOptions.None);
            var parsedContent = new string[lines.Length];

            for(int i = 0; i < lines.Length; i++)
            {
                if(lines[i].StartsWith(MarkdownTag))
                {
                    if(openTagIndex == baseIndex)
                    {
                        openTagIndex = i;
                    }
                    else if(closeTagIndex == baseIndex)
                    {
                        closeTagIndex = i;
                    }

                    if(openTagIndex != baseIndex && closeTagIndex != baseIndex)
                    {
                        parsedContent[i] = lines[i].Replace(MarkdownTag, HtmlEndTag);
                        parsedContent[openTagIndex] = parsedContent[openTagIndex].Replace(MarkdownTag, HtmlBeginTag);

                        openTagIndex = baseIndex;
                        closeTagIndex = baseIndex;
                    }
                    else
                    {
                        parsedContent[i] = lines[i];
                    }
                }
                else
                {
                    parsedContent[i] = lines[i];
                }
            }

            return string.Join(Environment.NewLine, parsedContent);
        }
    }
}