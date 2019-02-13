using System;
using Xunit;
using LoggingKata;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort", "34.073638, -84.677017, Taco Bell Acwort")]
        public void ShouldParse(string line, ITrackable expected)
        {
            // arrange
            TacoParser tacoParser = new TacoParser();

            // act
            ITrackable actual = tacoParser.Parse(line);

            // assert
            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
        }
    }
}
