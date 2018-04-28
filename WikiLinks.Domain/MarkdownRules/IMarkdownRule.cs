namespace WikiLinks.Domain.MarkdownRules
{
    public interface IMarkdownRule
    {
        string Parse(string content);
    }
}
