using FluentAssertions;
using Xunit;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.UnitTests.Models.DimensionTests
{
    public static class GetOffsetYTests
    {
        public sealed class Given_A_Dimension_Without_Offset_Provided_When_Retrieving_Its_OffsetY
            : Given_When_Then_Test
        {
            private Dimension _sut; 
            private int _result;
            private int _expectedResult;

            protected override void Given()
            {
                const int dimensionX = 30;
                const int dimensionY = 10;

                _sut = new Dimension(dimensionX, dimensionY);
                _expectedResult = default(int);
            }

            protected override void When()
            {
                _result = _sut.GetOffsetY();
            }

            [Fact]
            public void Then_It_Should_Return_The_Expected_Result()
            {
                _result.Should().Be(_expectedResult);
            }
        }

        public sealed class Given_A_Dimension_With_Offset_Provided_When_Retrieving_Its_OffsetY
            : Given_When_Then_Test
        {
            private Dimension _sut;
            private int _result;
            private int _expectedResult;

            protected override void Given()
            {
                const int dimensionX = 100;
                const int dimensionY = 25;
                const int offsetX = 10;
                const int offsetY = 5;

                _sut = new Dimension(dimensionX, dimensionY, offsetX, offsetY);
                _expectedResult = offsetY;
            }

            protected override void When()
            {
                _result = _sut.GetOffsetY();
            }

            [Fact]
            public void Then_It_Should_Return_The_Expected_Result()
            {
                _result.Should().Be(_expectedResult);
            }
        }
    }
}
