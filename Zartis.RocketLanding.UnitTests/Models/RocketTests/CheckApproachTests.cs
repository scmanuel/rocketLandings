using FluentAssertions;
using Moq;
using System;
using Xunit;
using Zartis.RocketLanding.Contracts;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.UnitTests.Models.RocketTests
{
    public static class CheckApproachTests
    {
        public sealed class Given_A_PositionX_And_A_PositionY_When_Checking_A_Landing_Position
            : Given_When_Then_Test
        {
            private Rocket _sut;
            private Mock<ILandingArea> _areaMock;
            private int _positionX;
            private int _positionY;
            private string _result;
            private string _expectedResult;

            protected override void Given()
            {
                _positionX = 10;
                _positionY = 20;

                _areaMock = new Mock<ILandingArea>();
                _expectedResult = "ok";
                _areaMock
                    .Setup(s => s.CheckApproach(It.IsAny<Guid>(), It.IsAny<IPosition>()))
                    .Returns(_expectedResult);
                 var area = _areaMock.Object;

                _sut = new Rocket(area);
            }

            protected override void When()
            {
                _result = _sut.CheckApproach(_positionX, _positionY);
            }

            [Fact]
            public void Then_It_Should_Retrieve_A_Message_String_Value()
            {
                _result.Should().BeAssignableTo<string>();
            }

            [Fact]
            public void Then_It_Should_Check_The_Landing_Approach_From_The_Landing_Area()
            {
                _areaMock.Verify(a => a.CheckApproach(It.IsAny<Guid>(), It.IsAny<IPosition>()), Times.Once);
            }

            [Fact]
            public void Then_It_Should_Retrieve_The_Same_Value_Returned_By_The_Landing_Strategy()
            {
                _result.Should().Be(_expectedResult);
            }
        }
    }
}
