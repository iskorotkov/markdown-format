using System;
using System.Threading.Tasks;

namespace MarkdownFormat.IO.Console
{
    public class ConsoleReader : IReader
    {
        public class UserInputException : ApplicationException
        {
            public UserInputException() : base("Input value is null.")
            {
            }
        }

        public Task<string> ReadLineAsync()
        {
            var input = System.Console.ReadLine() ?? throw new UserInputException();
            return Task.FromResult(input);
        }
    }
}
