using FluentAssertions;
using Xunit;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.UnitTests.Models.DimensionTests
{
    public static class GetOffsetXTests
    {
        public sealed class Given_A_Dimension_Without_Offset_Provided_When_Retrieving_Its_OffsetX
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
                _expectedResult = default(int);
            }

            protected override void When()
            {
                _result = _sut.GetOffsetX();
            }

            [Fact]
            public void Then_It_Should_Return_The_Expected_Result()
            {
                _result.Should().Be(_expectedResult);
            }
        }

        public sealed class Given_A_Dimension_With_Offset_Provided_When_Retrieving_Its_OffsetX
            : Given_When_Then_Test
        {
            private Dimension _sut;
            private int _result;
            private int _expectedResult;

            protected override void Given()
            {
                const int dimensionX = 70;
                const int dimensionY = 25;
                const int offsetX = 10;

                _sut = new Dimension(dimensionX, dimensionY, offsetX);
                _expectedResult = offsetX;
            }

            protected override void When()
            {
                _result = _sut.GetOffsetX();
            }

            [Fact]
            public void Then_It_Should_Return_The_Expected_Result()
            {
                _result.Should().Be(_expectedResult);
            }
        }
    }
}
