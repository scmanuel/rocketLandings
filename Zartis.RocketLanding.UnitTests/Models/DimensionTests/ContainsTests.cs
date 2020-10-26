using FluentAssertions;
using Xunit;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.UnitTests.Models.DimensionTests
{
    public static class ContainsTests
    {
        public sealed class Given_A_Dimension_Which_Contains_Another_Dimension_When_Checking_If_Contains
            : Given_When_Then_Test
        {
            private Dimension _sut; 
            private Dimension _subArea;
            private bool _result;
            private bool _expectedResult;

            protected override void Given()
            {
                const int subAreDimensionX = 50;
                const int subAreaDimensionY = 70;
                const int dimensionX = 100;
                const int dimensionY = 100;

                _subArea = new Dimension(subAreDimensionX, subAreaDimensionY);
                _sut = new Dimension(dimensionX, dimensionY);
                _expectedResult = true;
            }

            protected override void When()
            {
                _result = _sut.Contains(_subArea);
            }

            [Fact]
            public void Then_It_Should_Return_The_Expected_Result()
            {
                _result.Should().Be(_expectedResult);
            }
        }

        public sealed class Given_A_Dimension_Which_Doesnt_Contains_Another_Dimension_When_Checking_If_Contains
            : Given_When_Then_Test
        {
            private Dimension _sut;
            private Dimension _subArea;
            private bool _result;
            private bool _expectedResult;

            protected override void Given()
            {
                const int subAreDimensionX = 120;
                const int subAreaDimensionY = 60;
                const int dimensionX = 100;
                const int dimensionY = 100;

                _subArea = new Dimension(subAreDimensionX, subAreaDimensionY);
                _sut = new Dimension(dimensionX, dimensionY);
                _expectedResult = false;
            }

            protected override void When()
            {
                _result = _sut.Contains(_subArea);
            }

            [Fact]
            public void Then_It_Should_Return_The_Expected_Result()
            {
                _result.Should().Be(_expectedResult);
            }
        }

        public sealed class Given_A_Dimension_Which_Contains_A_Position_When_Checking_If_Contains
            : Given_When_Then_Test
        {
            private Dimension _sut;
            private Position _position;
            private bool _result;
            private bool _expectedResult;

            protected override void Given()
            {
                const int positionX = 20;
                const int positionY = 30;
                const int dimensionX = 100;
                const int dimensionY = 100;

                _position = new Position(positionX, positionY);
                _sut = new Dimension(dimensionX, dimensionY);
                _expectedResult = true;
            }

            protected override void When()
            {
                _result = _sut.Contains(_position);
            }

            [Fact]
            public void Then_It_Should_Return_The_Expected_Result()
            {
                _result.Should().Be(_expectedResult);
            }
        }

        public sealed class Given_A_Dimension_Which_Doesnt_Contains_A_Position_When_Checking_If_Contains
            : Given_When_Then_Test
        {
            private Dimension _sut;
            private Position _position;
            private bool _result;
            private bool _expectedResult;

            protected override void Given()
            {
                const int positionX = 20;
                const int positionY = 5;
                const int dimensionX = 10;
                const int dimensionY = 35;

                _position = new Position(positionX, positionY);
                _sut = new Dimension(dimensionX, dimensionY);
                _expectedResult = false;
            }

            protected override void When()
            {
                _result = _sut.Contains(_position);
            }

            [Fact]
            public void Then_It_Should_Return_The_Expected_Result()
            {
                _result.Should().Be(_expectedResult);
            }
        }
    }
}
