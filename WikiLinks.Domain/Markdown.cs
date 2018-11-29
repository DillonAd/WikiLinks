using System;
using System.Text;
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
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            var lines = content.Split('\n');

            var line = string.Empty;

            for(int i = 0; i < lines.Length; i++)
            {
                foreach(var rule in _Rules)
                {
                    line = rule.Parse(lines[i]);
                }

                sb.Append(line)
                  .Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
