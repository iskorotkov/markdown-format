using Microsoft.Extensions.DependencyInjection;

namespace MarkdownFormat.IO.Console
{
    public static class DependencyInjection
    {
        // ReSharper disable once InconsistentNaming
        public static void AddConsoleIO(this IServiceCollection services)
        {
            services.AddTransient<IReader, ConsoleReader>();
            services.AddTransient<IWriter, ConsoleWriter>();
        }
    }
}
