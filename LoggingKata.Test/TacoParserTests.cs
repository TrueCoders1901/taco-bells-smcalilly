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
       // string with one comma etc
       // longitute > maximum longitude

        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
        }
    }
}
