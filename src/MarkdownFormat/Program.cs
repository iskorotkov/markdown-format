using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using MarkdownFormat.Formatters;
using MarkdownFormat.IO.Console;
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

            var fileArgument = new Option(new[] {"--input", "-i"}, "input file");
            root.AddOption(fileArgument);

            return root;
        }

        private static async Task Run(string? filename)
        {
            var provider = ConfigureServices(filename);
            var processor = provider.GetRequiredService<IMarkdownProcessor>();
            await processor.RunAsync();
        }

        private static ServiceProvider ConfigureServices(string? filename)
        {
            var services = new ServiceCollection();

            services.AddScoped<IMarkdownProcessor, MarkdownProcessor>();
            services.AddScoped<IMarkdownFormatter, SubscriptFormatter>();

            services.AddSingleton<IMarkdownFormatter, SubscriptFormatter>();

            if (filename is null)
            {
                services.AddConsoleIO();
            }

            return services.BuildServiceProvider();
        }
    }
}
