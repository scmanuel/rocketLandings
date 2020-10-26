using FluentAssertions;
using Xunit;
using Zartis.RocketLanding.Enums;
using Zartis.RocketLanding.LandingStrategies;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport.Factories;

namespace Zartis.RocketLanding.UnitTests.LandingStrategies.ZartisExerciseStrategyTests
{
    public static class CheckApproachOkTests
    {
        [Theory]
        [InlineData(3, 5)]
        [InlineData(7, 5)]
        [InlineData(4, 7)]
        [InlineData(5, 7)]
        [InlineData(6, 7)]
        [InlineData(4, 3)]
        [InlineData(5, 3)]
        [InlineData(6, 3)]
        private static void Given_A_Landing_Strategy_And_A_Valid_Position_When_Checking_A_Landing_Position(int positionXRocketTwo, int positionYRocketTwo)
        {
            // Arrange
            const int positionXRocketOne = 5;
            const int positionYRocketOne = 5;
            const ApproachCheckResult expectedResult = ApproachCheckResult.Ok;

            var rocketOneId = GuidGenerator.Create(1);
            var positionRocketOne = new Position(positionXRocketOne, positionYRocketOne);

            var rocketTwoId = GuidGenerator.Create(2);
            var positionRocketTwo = new Position(positionXRocketTwo, positionYRocketTwo);

            var platformDimension = new Dimension(10, 10);
            var sut = new ZartisExerciseStrategy();
            sut.CheckApproach(rocketOneId, positionRocketOne, platformDimension);

            // Act
            var result = sut.CheckApproach(rocketTwoId, positionRocketTwo, platformDimension);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}