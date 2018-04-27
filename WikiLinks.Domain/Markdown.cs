using System.Collections.Generic;
using WikiLinks.Domain.MarkdownRules;

namespace WikiLinks.Domain
{
    public class Markdown
    {
        private List<IMarkdownRule> _Rules;

        public Markdown()
        {
            _Rules = new List<IMarkdownRule>();
        }

        public string Parse(string content)
        {
            string parsedContent = content;

            foreach(var rule in _Rules)
            {
                parsedContent = rule.ParseRule(parsedContent);
            }

            return parsedContent;
        }
    }
}
