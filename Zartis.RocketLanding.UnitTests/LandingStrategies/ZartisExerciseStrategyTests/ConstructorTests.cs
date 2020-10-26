using FluentAssertions;
using Xunit;
using Zartis.RocketLanding.Contracts;
using Zartis.RocketLanding.LandingStrategies;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.UnitTests.LandingStrategies.ZartisExerciseStrategyTests
{
    public static class ConstructorTests
    {
        public sealed class Given_Valid_Dependencies_When_Constructing_Instance
        : Given_When_Then_Test
        {
            private ZartisExerciseStrategy _sut;

            protected override void Given()
            {
            }

            protected override void When()
            {
                _sut = new ZartisExerciseStrategy();
            }

            [Fact]
            public void Then_It_Should_Have_Created_A_Valid_Instance()
            {
                _sut.Should().NotBeNull();
            }

            [Fact]
            public void Then_It_Should_Be_An_ILandingStrategy()
            {
                _sut.Should().BeAssignableTo<ILandingStrategy>();
            }
        }
    }
}
