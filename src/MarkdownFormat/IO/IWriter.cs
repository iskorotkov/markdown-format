using System.Threading.Tasks;

namespace MarkdownFormat.IO
{
    public interface IWriter
    {
        Task WriteLineAsync(string line);
    }
}
