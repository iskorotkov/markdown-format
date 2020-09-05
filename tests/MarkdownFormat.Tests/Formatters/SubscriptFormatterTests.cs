using MarkdownFormat.Formatters;
using Shouldly;
using Xunit;

namespace MarkdownFormat.Tests.Formatters
{
    public class SubscriptFormatterTests
    {
        private readonly SubscriptFormatter _formatter = new SubscriptFormatter();

        [Theory]
        [InlineData("word")]
        [InlineData("1234567890")]
        [InlineData("_abc_")]
        [InlineData("__abc__")]
        [InlineData("some__text"),]
        public void PlainWordsShouldBeLeftAsIs(string word)
        {
            _formatter.Run(word).ShouldBe(word);
        }

        [Theory]
        [InlineData("t_1", "t<sub>1</sub>")]
        [InlineData("t_123", "t<sub>123</sub>")]
        [InlineData("velocity_max", "velocity<sub>max</sub>")]
        [InlineData("abc123_xyz987", "abc123<sub>xyz987</sub>")]
        [InlineData("x_1, x_2, x_3", "x<sub>1</sub>, x<sub>2</sub>, x<sub>3</sub>")]
        [InlineData("where t_1=12 and x=10;", "where t<sub>1</sub>=12 and x=10;")]
        public void SubscriptShouldBeReplaced(string before, string after)
        {
            _formatter.Run(before).ShouldBe(after);
        }

        [Theory]
        [InlineData("t_a_2", "t<sub>a<sub></sub>2</sub>")]
        public void SeveralNestedSubscripts(string before, string after)
        {
            _formatter.Run(before).ShouldBe(after);
        }
    }
}
