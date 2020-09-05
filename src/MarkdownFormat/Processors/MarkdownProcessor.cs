using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkdownFormat.Formatters;
using MarkdownFormat.IO;

namespace MarkdownFormat.Processors
{
    public class MarkdownProcessor : IMarkdownProcessor
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private readonly IEnumerable<IMarkdownFormatter> _formatters;

        public MarkdownProcessor(IReader reader, IWriter writer, IEnumerable<IMarkdownFormatter> formatters)
        {
            _reader = reader;
            _writer = writer;
            _formatters = formatters;
        }

        public async Task RunAsync()
        {
            var line = await _reader.ReadLineAsync();
            line = _formatters.Aggregate(line, (current, formatter) => formatter.Run(current));
            await _writer.WriteLineAsync(line);
        }
    }
}
