using System;
using System.Collections.Generic;
using System.Text;

namespace WikiLinks.Domain.MarkdownRules
{
    public interface IMarkdownRule
    {
        string ParseRule(string content);
    }
}
