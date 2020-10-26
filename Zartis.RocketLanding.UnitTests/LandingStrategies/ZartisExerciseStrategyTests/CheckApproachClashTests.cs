using FluentAssertions;
using Xunit;
using Zartis.RocketLanding.Enums;
using Zartis.RocketLanding.LandingStrategies;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport.Factories;

namespace Zartis.RocketLanding.UnitTests.LandingStrategies.ZartisExerciseStrategyTests
{
    public static class CheckApproachClashTests
    {
        [Theory]
        [InlineData(10, 10)]
        [InlineData(9, 10)]
        [InlineData(11, 10)]
        [InlineData(9, 11)]
        [InlineData(10, 11)]
        [InlineData(11, 11)]
        [InlineData(9, 9)]
        [InlineData(10, 9)]
        [InlineData(11, 9)]
        private static void Given_A_Landing_Strategy_And_A_Position_Close_To_Another_Checked_Position_When_Checking_A_Landing_Position(int positionXRocketTwo, int positionYRocketTwo)
        {
            // Arrange
            const int positionXRocketOne = 10;
            const int positionYRocketOne = 10;
            const ApproachCheckResult expectedResult = ApproachCheckResult.Clash;

            var rocketOneId = GuidGenerator.Create(1);
            var positionRocketOne = new Position(positionXRocketOne, positionYRocketOne);

            var rocketTwoId = GuidGenerator.Create(2);
            var positionRocketTwo = new Position(positionXRocketTwo, positionYRocketTwo);

            var platformDimension = new Dimension(10, 10, 2, 2);
            var sut = new ZartisExerciseStrategy();
            sut.CheckApproach(rocketOneId, positionRocketOne, platformDimension);

            // Act
            var result = sut.CheckApproach(rocketTwoId, positionRocketTwo, platformDimension);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
