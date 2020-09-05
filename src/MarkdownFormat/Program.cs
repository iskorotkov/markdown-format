using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;
using MarkdownFormat.IO;
using MarkdownFormat.Processors;
using Microsoft.Extensions.DependencyInjection;

namespace MarkdownFormat
{
    internal static class Program
    {
        private static async Task<int> Main(string[] args)
        {
            return await ConfigureCommandLineInterface()
                .InvokeAsync(args);
        }

        private static RootCommand ConfigureCommandLineInterface()
        {
            var root = new RootCommand
            {
                Handler = CommandHandler.Create<string>(Run),
            };

            var fileArgument = new Argument("filename")
            {
                ArgumentType = typeof(FileInfo),
                Arity = new ArgumentArity(0, 1),
            };
            root.AddArgument(fileArgument);

            return root;
        }

        private static void Run(string? filename)
        {
            var services = new ServiceCollection();
            services.AddScoped<IMarkdownProcessor, MarkdownProcessor>();
            services.AddTransient<IReader>();
            services.AddTransient<IWriter>();
            var provider = services.BuildServiceProvider();
            var processor = provider.GetRequiredService<IMarkdownProcessor>();
        }
    }
}
