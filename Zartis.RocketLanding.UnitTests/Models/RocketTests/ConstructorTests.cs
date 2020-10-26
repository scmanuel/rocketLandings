using FluentAssertions;
using Moq;
using System;
using Xunit;
using Zartis.RocketLanding.Contracts;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.UnitTests.Models.RocketTests
{
    public static class ConstructorTests
    {
        public sealed class Given_Valid_Dependencies_When_Constructing_Instance
        : Given_When_Then_Test
        {
            private Rocket _sut;
            private ILandingArea _area;

            protected override void Given()
            {
                _area = Mock.Of<ILandingArea>();
            }

            protected override void When()
            {
                _sut = new Rocket(_area);
            }

            [Fact]
            public void Then_It_Should_Have_Created_A_Valid_Instance()
            {
                _sut.Should().NotBeNull();
            }

            [Fact]
            public void Then_It_Should_Be_An_IRocket()
            {
                _sut.Should().BeAssignableTo<IRocket>();
            }
        }

        public sealed class Given_Missing_Landing_Area_Dependency_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private Rocket _sut;
            private ILandingArea _area;
            private Exception _expectedException;

            protected override void Given()
            {
                _area = default(ILandingArea);
            }

            protected override void When()
            {
                _expectedException = Record.Exception(
                    () => _sut = new Rocket(_area));
            }

            [Fact]
            public void Then_It_Should_Not_Create_An_Instance()
            {
                _sut.Should().BeNull();
            }

            [Fact]
            public void Then_It_Should_Throw_An_ArgumentNullException()
            {
                _expectedException.Should().BeAssignableTo<ArgumentNullException>();
            }
        }
    }    
}
