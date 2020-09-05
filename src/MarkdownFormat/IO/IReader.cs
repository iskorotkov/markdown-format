using System.Threading.Tasks;

namespace MarkdownFormat.IO
{
    public interface IReader
    {
        Task<string> ReadLineAsync();
    }
}
