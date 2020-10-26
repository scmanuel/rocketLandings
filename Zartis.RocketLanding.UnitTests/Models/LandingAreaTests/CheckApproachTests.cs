using FluentAssertions;
using Moq;
using System;
using Xunit;
using Zartis.RocketLanding.Contracts;
using Zartis.RocketLanding.Enums;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;
using Zartis.RocketLanding.TestSupport.Factories;

namespace Zartis.RocketLanding.UnitTests.Models.LandingAreaTests
{
    public static class CheckApproachTests
    {
        public sealed class Given_A_Landing_Area_And_A_Position_When_Checking_A_Landing_Position
            : Given_When_Then_Test
        {
            private const ApproachCheckResult ApproachCheckResult = Enums.ApproachCheckResult.Ok;

            private LandingArea _sut;
            private Mock<IApproachCheckResultMapper> _approachCheckResultMapperMock;
            private Mock<ILandingPlatform> _platformMock;
            private Guid _rocketId;
            private IPosition _position;
            private string _result;
            private string _expectedResult;

            protected override void Given()
            {
                const int areaDimensionX = 100;
                const int areaDimensionY = 100;
                const int platformDimensionX = 50;
                const int platformDimensionY = 50;

                var platformDimension = new Dimension(platformDimensionX, platformDimensionY);
                var areaDimension = new Dimension(areaDimensionX, areaDimensionY);

                _rocketId = GuidGenerator.Create(1);
                _position = Mock.Of<IPosition>();

                _platformMock = new Mock<ILandingPlatform>();
                _platformMock
                    .Setup(m => m.GetDimension())
                    .Returns(platformDimension);
                _platformMock
                    .Setup(m => m.CheckApproach(_rocketId, _position))
                    .Returns(ApproachCheckResult);
                var platform = _platformMock.Object;

                _expectedResult = "ok";
                _approachCheckResultMapperMock = new Mock<IApproachCheckResultMapper>();
                _approachCheckResultMapperMock
                    .Setup(m => m.Map(ApproachCheckResult))
                    .Returns(_expectedResult);
                var approachCheckResultMapper = _approachCheckResultMapperMock.Object;

                _sut = new LandingArea(areaDimension, platform, approachCheckResultMapper);
            }

            protected override void When()
            {
                _result = _sut.CheckApproach(_rocketId, _position);
            }

            [Fact]
            public void Then_It_Should_Retrieve_A_Message_String_Value()
            {
                _result.Should().BeAssignableTo<string>();
            }

            [Fact]
            public void Then_It_Should_Get_The_Landing_Platform_Dimension()
            {
                _platformMock.Verify(s => s.GetDimension(), Times.Once);
            }

            [Fact]
            public void Then_It_Should_Map_The_ApproachCheckResult()
            {
                _approachCheckResultMapperMock.Verify(m => m.Map(ApproachCheckResult), Times.Once);
            }

            [Fact]
            public void Then_It_Should_Retrieve_The_ApproachCheckResult_Mapped_Value()
            {
                _result.Should().Be(_expectedResult);
            }
        }

        public sealed class Given_A_Landing_Area_And_A_Missing_Position_When_Checking_A_Landing_Position
            : Given_When_Then_Test
        {
            private LandingArea _sut;
            private Mock<IApproachCheckResultMapper> _approachCheckResultMapperMock;
            private Mock<ILandingPlatform> _platformMock;
            private Guid _rocketId;
            private IPosition _position;
            private Exception _expectedException;

            protected override void Given()
            {
                const int areaDimensionX = 100;
                const int areaDimensionY = 100;
                const int platformDimensionX = 50;
                const int platformDimensionY = 50;

                var platformDimension = new Dimension(platformDimensionX, platformDimensionY);
                var areaDimension = new Dimension(areaDimensionX, areaDimensionY);

                _rocketId = GuidGenerator.Create(1);
                _position = default(IPosition);

                _platformMock = new Mock<ILandingPlatform>();
                _platformMock
                    .Setup(m => m.GetDimension())
                    .Returns(platformDimension);
                var platform = _platformMock.Object;

                _approachCheckResultMapperMock = new Mock<IApproachCheckResultMapper>();
                var approachCheckResultMapper = _approachCheckResultMapperMock.Object;

                _sut = new LandingArea(areaDimension, platform, approachCheckResultMapper);
            }

            protected override void When()
            {
                _expectedException = Record.Exception(
                    () => _sut.CheckApproach(_rocketId, _position));
            }

            [Fact]
            public void Then_It_Should_Throw_An_ArgumentNullException()
            {
                _expectedException.Should().BeAssignableTo<ArgumentNullException>();
            }
        }
    }
}
