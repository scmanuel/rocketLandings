using FluentAssertions;
using Moq;
using Xunit;
using Zartis.RocketLanding.Contracts;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.UnitTests.Models.LandingPlatformTests
{
    public static class GetDimensionTests
    {
        public sealed class Given_A_LandingPlatform_When_Retrieving_Its_Dimension
            : Given_When_Then_Test
        {
            private LandingPlatform _sut;
            private IDimension _platformDimension;
            private ILandingStrategy _strategy;
            private IDimension _result;            

            protected override void Given()
            {
                _platformDimension = Mock.Of<IDimension>();
                _strategy = Mock.Of<ILandingStrategy>();
                _sut = new LandingPlatform(_platformDimension, _strategy);
            }

            protected override void When()
            {
                _result = _sut.GetDimension();
            }

            [Fact]
            public void Then_It_Should_Retrieve_An_IDimension_Instance()
            {
                _result.Should().BeAssignableTo<IDimension>();
            }

            [Fact]
            public void Then_It_Should_Retrieve_The_Right_Dimension()
            {
                _result.Should().BeEquivalentTo(_platformDimension);
            }
        }
    }    
}
