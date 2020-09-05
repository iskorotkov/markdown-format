using System.Threading.Tasks;

namespace MarkdownFormat.IO.Console
{
    public class ConsoleWriter : IWriter
    {
        public Task WriteLineAsync(string line)
        {
            System.Console.WriteLine(line);
            return Task.CompletedTask;
        }
    }
}
