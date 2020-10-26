using FluentAssertions;
using System;
using Xunit;
using Zartis.RocketLanding.Contracts;
using Zartis.RocketLanding.LandingStrategies;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;
using Zartis.RocketLanding.TestSupport.Factories;

namespace Zartis.RocketLanding.UnitTests.LandingStrategies.ZartisExerciseStrategyTests
{
    public static class CheckApproachMissingParametersTests
    {
        public sealed class Given_A_Landing_Strategy_And_A_Missing_Position_When_Checking_A_Landing_Position
            : Given_When_Then_Test
        {
            private ZartisExerciseStrategy _sut;
            private Guid _rocketId;
            private IPosition _position;
            private IDimension _platformDimension;
            private Exception _expectedException;

            protected override void Given()
            {
                _rocketId = GuidGenerator.Create(1);
                _position = default(IPosition);
                _platformDimension = new Dimension(10, 10, 2, 2);
                _sut = new ZartisExerciseStrategy();
            }

            protected override void When()
            {
                _expectedException = Record.Exception(
                    () => _sut.CheckApproach(_rocketId, _position, _platformDimension));
            }

            [Fact]
            public void Then_It_Should_Throw_An_ArgumentNullException()
            {
                _expectedException.Should().BeAssignableTo<ArgumentNullException>();
            }
        }

        public sealed class Given_A_Landing_Strategy_And_A_Missing_Platform_Dimension_When_Checking_A_Landing_Position
            : Given_When_Then_Test
        {
            private ZartisExerciseStrategy _sut;
            private Guid _rocketId;
            private IPosition _position;
            private IDimension _platformDimension;
            private Exception _expectedException;

            protected override void Given()
            {
                const int positionX = 10;
                const int positionY = 10;
                _rocketId = GuidGenerator.Create(1);
                
                _position = new Position(positionX, positionY);
                _platformDimension = default(IDimension);
                _sut = new ZartisExerciseStrategy();
            }

            protected override void When()
            {
                _expectedException = Record.Exception(
                    () => _sut.CheckApproach(_rocketId, _position, _platformDimension));
            }

            [Fact]
            public void Then_It_Should_Throw_An_ArgumentNullException()
            {
                _expectedException.Should().BeAssignableTo<ArgumentNullException>();
            }
        }
    }
}
