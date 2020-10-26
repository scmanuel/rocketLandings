using FluentAssertions;
using Xunit;
using Zartis.RocketLanding.Contracts;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.UnitTests.Models.DimensionTests
{
    public static class ConstructorTests
    {
        public sealed class Given_A_Valid_Dimension_When_Constructing_Instance
        : Given_When_Then_Test
        {
            private Dimension _sut;
            private int _dimensionX;
            private int _dimensionY;

            protected override void Given()
            {
                _dimensionX = 5;
                _dimensionY = 10;
            }

            protected override void When()
            {
                _sut = new Dimension(_dimensionX, _dimensionY);
            }

            [Fact]
            public void Then_It_Should_Have_Created_A_Valid_Instance()
            {
                _sut.Should().NotBeNull();
            }

            [Fact]
            public void Then_It_Should_Be_An_IDimension()
            {
                _sut.Should().BeAssignableTo<IDimension>();
            }
        }

        public sealed class Given_A_Valid_Dimension_And_Offset_Values_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private Dimension _sut;
            private int _dimensionX;
            private int _dimensionY;
            private int _offsetX;
            private int _offsetY;

            protected override void Given()
            {
                _dimensionX = 5;
                _dimensionY = 10;
                _offsetX = 5;
                _offsetY = 5;
            }

            protected override void When()
            {
                _sut = new Dimension(_dimensionX, _dimensionY, _offsetX, _offsetY);
            }

            [Fact]
            public void Then_It_Should_Have_Created_A_Valid_Instance()
            {
                _sut.Should().NotBeNull();
            }

            [Fact]
            public void Then_It_Should_Be_An_IDimension()
            {
                _sut.Should().BeAssignableTo<IDimension>();
            }
        }
    }    
}
