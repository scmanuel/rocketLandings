using FluentAssertions;
using Moq;
using System;
using Xunit;
using Zartis.RocketLanding.Contracts;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.UnitTests.Models.LandingPlatformTests
{
    public static class ConstructorTests
    {
        public sealed class Given_Valid_Dependencies_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private LandingPlatform _sut;
            private IDimension _platformDimension;
            private ILandingStrategy _strategy;

            protected override void Given()
            {
                _platformDimension = Mock.Of<IDimension>();
                _strategy = Mock.Of<ILandingStrategy>();
            }

            protected override void When()
            {
                _sut = new LandingPlatform(_platformDimension, _strategy);
            }

            [Fact]
            public void Then_It_Should_Have_Created_A_Valid_Instance()
            {
                _sut.Should().NotBeNull();
            }

            [Fact]
            public void Then_It_Should_Be_An_ILandingPlatform()
            {
                _sut.Should().BeAssignableTo<ILandingPlatform>();
            }
        }

        public sealed class Given_Missing_Platform_Dimension_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private LandingPlatform _sut;
            private IDimension _platformDimension;
            private ILandingStrategy _strategy;
            private Exception _expectedException;

            protected override void Given()
            {
                _platformDimension = default(IDimension);
                _strategy = Mock.Of<ILandingStrategy>();
            }

            protected override void When()
            {
                _expectedException = Record.Exception(
                    () => _sut = new LandingPlatform(_platformDimension, _strategy));
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

        public sealed class Given_Missing_Landing_Strategy_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private LandingPlatform _sut;
            private IDimension _platformDimension;
            private ILandingStrategy _strategy;
            private Exception _expectedException;

            protected override void Given()
            {
                _platformDimension = Mock.Of<IDimension>();
                _strategy = default(ILandingStrategy);
            }

            protected override void When()
            {
                _expectedException = Record.Exception(
                    () => _sut = new LandingPlatform(_platformDimension, _strategy));
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
