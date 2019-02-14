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
        [InlineData("34.073638,-84.677017,Taco Bell Acwort")]
        [InlineData("34,-84,Taco Bell")]
        [InlineData("34.795116,-86.97191,Taco Bell Athens")]
        public void ShouldParse(string line)
        {
            // arrange
            TacoParser tacoParser = new TacoParser();

            // act
            ITrackable actual = tacoParser.Parse(line);

            // assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("33.323, 23.223")]
        [InlineData("181, 23.223, taco bell")]

        public void ShouldFailParse(string line)
        {
            // arrange
            TacoParser tacoParser = new TacoParser();

            // act
            ITrackable actual = tacoParser.Parse(line);

            // assert
            Assert.Null(actual);
        }
    }
}
