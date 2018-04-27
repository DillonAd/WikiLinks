using System;
using System.Collections.Generic;
using System.Text;

namespace WikiLinks.Domain.MarkdownRules
{
    public class BoldRule : MarkdownRule, IMarkdownRule
    {
        private const string _MarkdownTag = "**";
        private const string _HtmlBeginTag = "<b>";
        private const string _HtmlEndTag = "</b>";

        public BoldRule() : base(_MarkdownTag, _HtmlBeginTag, _HtmlEndTag) { }
    }
}
