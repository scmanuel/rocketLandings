using FluentAssertions;
using Xunit;
using Zartis.RocketLanding.LandingStrategies;
using Zartis.RocketLanding.Mappers;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.ComponentTests.ZartisExerciseStrategyTests
{
    public static class CheckApproach
    {
        public sealed class Given_A_Rocket_And_A_Valid_Position_When_Checking_The_Landing_Position
            : Given_When_Then_Test
        {
            private Rocket _sut;
            private int _positionX;
            private int _positionY;
            private string _result;
            private string _expectedResult;

            protected override void Given()
            {
                const int areaDimensionX = 100;
                const int areaDimensionY = 100;
                const int platformDimensionX = 50;
                const int platformDimensionY = 50;

                _positionX = 20;
                _positionY = 25;

                var approachCheckResultMapper = new ApproachCheckResultMapper();
                var strategy = new ZartisExerciseStrategy();
                var platformDimension = new Dimension(platformDimensionX, platformDimensionY);
                var platform = new LandingPlatform(platformDimension, strategy);
                var areaDimension = new Dimension(areaDimensionX, areaDimensionY);
                var area = new LandingArea(areaDimension, platform, approachCheckResultMapper);

                _sut = new Rocket(area);

                _expectedResult = "ok for landing";
            }

            protected override void When()
            {
                _result = _sut.CheckApproach(_positionX, _positionY);
            }

            [Fact]
            public void Then_It_Should_Retrieve_Ok_For_Landing_Message()
            {
                _result.Should().Be(_expectedResult);
            }
        }

        public sealed class Given_A_Rocket_And_An_Out_Position_When_Checking_The_Landing_Position
            : Given_When_Then_Test
        {
            private Rocket _sut;
            private int _positionX;
            private int _positionY;
            private string _result;
            private string _expectedResult;

            protected override void Given()
            {
                const int areaDimensionX = 100;
                const int areaDimensionY = 100;
                const int platformDimensionX = 50;
                const int platformDimensionY = 50;

                _positionX = 70;
                _positionY = 40;

                var approachCheckResultMapper = new ApproachCheckResultMapper();
                var strategy = new ZartisExerciseStrategy();
                var platformDimension = new Dimension(platformDimensionX, platformDimensionY);
                var platform = new LandingPlatform(platformDimension, strategy);
                var areaDimension = new Dimension(areaDimensionX, areaDimensionY);
                var area = new LandingArea(areaDimension, platform, approachCheckResultMapper);

                _sut = new Rocket(area);

                _expectedResult = "out of platform";
            }

            protected override void When()
            {
                _result = _sut.CheckApproach(_positionX, _positionY);
            }

            [Fact]
            public void Then_It_Should_Retrieve_Out_Of_Platform_Message()
            {
                _result.Should().Be(_expectedResult);
            }
        }

        public sealed class Given_A_Rocket_And_A_Position_Already_Checked_By_Another_Rocket_When_Checking_The_Landing_Position
            : Given_When_Then_Test
        {
            private Rocket _sut;
            private int _positionX;
            private int _positionY;
            private string _result;
            private string _expectedResult;

            protected override void Given()
            {
                const int areaDimensionX = 100;
                const int areaDimensionY = 100;
                const int platformDimensionX = 50;
                const int platformDimensionY = 50;

                _positionX = 20;
                _positionY = 40;

                var approachCheckResultMapper = new ApproachCheckResultMapper();
                var strategy = new ZartisExerciseStrategy();
                var platformDimension = new Dimension(platformDimensionX, platformDimensionY);
                var platform = new LandingPlatform(platformDimension, strategy);
                var areaDimension = new Dimension(areaDimensionX, areaDimensionY);
                var area = new LandingArea(areaDimension, platform, approachCheckResultMapper);
                var rocket = new Rocket(area);
                rocket.CheckApproach(_positionX, _positionY);

                _sut = new Rocket(area);

                _expectedResult = "clash";
            }

            protected override void When()
            {
                _result = _sut.CheckApproach(_positionX, _positionY);
            }

            [Fact]
            public void Then_It_Should_Retrieve_Clash_Message()
            {
                _result.Should().Be(_expectedResult);
            }
        }

        public sealed class Given_A_Rocket_And_A_Position_Close_To_An_Already_Checked_Position_Of_Another_Rocket_When_Checking_The_Landing_Position
            : Given_When_Then_Test
        {
            private Rocket _sut;
            private int _positionX;
            private int _positionY;
            private int _closePositionX;
            private string _result;
            private string _expectedResult;

            protected override void Given()
            {
                const int areaDimensionX = 100;
                const int areaDimensionY = 100;
                const int platformDimensionX = 50;
                const int platformDimensionY = 50;

                _positionX = 20;
                _positionY = 40;

                var approachCheckResultMapper = new ApproachCheckResultMapper();
                var strategy = new ZartisExerciseStrategy();
                var platformDimension = new Dimension(platformDimensionX, platformDimensionY);
                var platform = new LandingPlatform(platformDimension, strategy);
                var areaDimension = new Dimension(areaDimensionX, areaDimensionY);
                var area = new LandingArea(areaDimension, platform, approachCheckResultMapper);
                var rocket = new Rocket(area);
                rocket.CheckApproach(_positionX, _positionY);

                _sut = new Rocket(area);

                _expectedResult = "clash";
                _closePositionX = _positionX + 1;
            }

            protected override void When()
            {
                _result = _sut.CheckApproach(_closePositionX, _positionY);
            }

            [Fact]
            public void Then_It_Should_Retrieve_Clash_Message()
            {
                _result.Should().Be(_expectedResult);
            }
        }

        public sealed class Given_Two_Rockets_And_Valid_Positions_When_Checking_The_Landing_Position
            : Given_When_Then_Test
        {
            private Rocket _sut;
            private int _positionX;
            private int _positionY;
            private int _farPositionX;
            private string _result;
            private string _expectedResult;

            protected override void Given()
            {
                const int areaDimensionX = 100;
                const int areaDimensionY = 100;
                const int platformDimensionX = 50;
                const int platformDimensionY = 50;

                _positionX = 20;
                _positionY = 40;

                var approachCheckResultMapper = new ApproachCheckResultMapper();
                var strategy = new ZartisExerciseStrategy();
                var platformDimension = new Dimension(platformDimensionX, platformDimensionY);
                var platform = new LandingPlatform(platformDimension, strategy);
                var areaDimension = new Dimension(areaDimensionX, areaDimensionY);
                var area = new LandingArea(areaDimension, platform, approachCheckResultMapper);
                var rocket = new Rocket(area);
                rocket.CheckApproach(_positionX, _positionY);

                _sut = new Rocket(area);

                _expectedResult = "ok for landing";
                _farPositionX = _positionX + 2;
            }

            protected override void When()
            {
                _result = _sut.CheckApproach(_farPositionX, _positionY);
            }

            [Fact]
            public void Then_It_Should_Retrieve_Ok_For_Landing_Message()
            {
                _result.Should().Be(_expectedResult);
            }
        }
    }
}
