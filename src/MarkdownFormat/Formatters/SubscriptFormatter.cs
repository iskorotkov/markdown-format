using System.Text.RegularExpressions;

namespace MarkdownFormat.Formatters
{
    public class SubscriptFormatter : IMarkdownFormatter
    {
        private static readonly Regex Regex = new Regex(@"([a-zA-Zа-яА-Я0-9]+)_([a-zA-Zа-яА-Я0-9]+)");

        public string Run(string source)
        {
            return Regex.Replace(source, match => $"{match.Groups[1]}<sub>{match.Groups[2]}</sub>");
        }
    }
}
