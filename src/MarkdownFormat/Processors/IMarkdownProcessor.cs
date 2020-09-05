using System.Threading.Tasks;

namespace MarkdownFormat.Processors
{
    public interface IMarkdownProcessor
    {
        Task RunAsync();
    }
}
