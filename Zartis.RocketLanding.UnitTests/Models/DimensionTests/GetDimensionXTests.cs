using FluentAssertions;
using Xunit;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.UnitTests.Models.DimensionTests
{
    public static class GetDimensionXTests
    {
        public sealed class Given_A_Dimension_When_Retrieving_Its_DimensionX
            : Given_When_Then_Test
        {
            private Dimension _sut; 
            private int _result;
            private int _expectedResult;

            protected override void Given()
            {
                const int dimensionX = 70;
                const int dimensionY = 25;

                _sut = new Dimension(dimensionX, dimensionY);
                _expectedResult = dimensionX;
            }

            protected override void When()
            {
                _result = _sut.GetDimensionX();
            }

            [Fact]
            public void Then_It_Should_Return_The_Expected_Result()
            {
                _result.Should().Be(_expectedResult);
            }
        }
    }
}
