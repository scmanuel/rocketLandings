using FluentAssertions;
using Xunit;
using Zartis.RocketLanding.Contracts;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.UnitTests.Models.PositionTests
{
    public static class ConstructorTests
    {
        public sealed class Given_Valid_Dependencies_When_Constructing_Instance
        : Given_When_Then_Test
        {
            private Position _sut;
            private int _positionX;
            private int _positionY;

            protected override void Given()
            {
                _positionX = 10;
                _positionY = 20;
            }

            protected override void When()
            {
                _sut = new Position(_positionX, _positionY);
            }

            [Fact]
            public void Then_It_Should_Have_Created_A_Valid_Instance()
            {
                _sut.Should().NotBeNull();
            }

            [Fact]
            public void Then_It_Should_Be_An_IPosition()
            {
                _sut.Should().BeAssignableTo<IPosition>();
            }
        }
    }    
}
