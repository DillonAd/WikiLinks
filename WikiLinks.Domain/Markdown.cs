using System.Collections.Generic;
using WikiLinks.Domain.MarkdownRules;

namespace WikiLinks.Domain
{
    public class Markdown
    {
        private List<IMarkdownRule> _Rules;

        public Markdown(List<IMarkdownRule> rules)
        {
            _Rules = rules;
        }

        public string Parse(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return string.Empty;

            string parsedContent = content;

            foreach(var rule in _Rules)
            {
                parsedContent = rule.Parse(parsedContent);
            }

            return parsedContent;
        }
    }
}
