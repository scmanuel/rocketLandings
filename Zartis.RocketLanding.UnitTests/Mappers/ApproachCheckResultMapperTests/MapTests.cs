using FluentAssertions;
using Xunit;
using Zartis.RocketLanding.Enums;
using Zartis.RocketLanding.Mappers;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.UnitTests.Mappers.ApproachCheckResultMapperTests
{
    public static class MapTests
    {
        public sealed class Given_An_ApproachCheckResultMapper_When_Mapping_Ok_Value
            : Given_When_Then_Test
        {
            private ApproachCheckResultMapper _sut;
            private ApproachCheckResult _approachCheckResult;
            private string _result;
            private string _expectedMessage;

            protected override void Given()
            {
                _sut = new ApproachCheckResultMapper();
                _approachCheckResult = ApproachCheckResult.Ok;
                _expectedMessage = "ok for landing";
            }

            protected override void When()
            {
                _result = _sut.Map(_approachCheckResult);
            }

            [Fact]
            public void Then_It_Should_Return_The_Expected_Message()
            {
                _result.Should().Be(_expectedMessage);
            }
        }

        public sealed class Given_An_ApproachCheckResultMapper_When_Mapping_Clash_Value
            : Given_When_Then_Test
        {
            private ApproachCheckResultMapper _sut;
            private ApproachCheckResult _approachCheckResult;
            private string _result;
            private string _expectedMessage;

            protected override void Given()
            {
                _sut = new ApproachCheckResultMapper();
                _approachCheckResult = ApproachCheckResult.Clash;
                _expectedMessage = "clash";
            }

            protected override void When()
            {
                _result = _sut.Map(_approachCheckResult);
            }

            [Fact]
            public void Then_It_Should_Return_The_Expected_Message()
            {
                _result.Should().Be(_expectedMessage);
            }
        }

        public sealed class Given_An_ApproachCheckResultMapper_When_Mapping_Out_Value
            : Given_When_Then_Test
        {
            private ApproachCheckResultMapper _sut;
            private ApproachCheckResult _approachCheckResult;
            private string _result;
            private string _expectedMessage;

            protected override void Given()
            {
                _sut = new ApproachCheckResultMapper();
                _approachCheckResult = ApproachCheckResult.Out;
                _expectedMessage = "out of platform";
            }

            protected override void When()
            {
                _result = _sut.Map(_approachCheckResult);
            }

            [Fact]
            public void Then_It_Should_Return_The_Expected_Message()
            {
                _result.Should().Be(_expectedMessage);
            }
        }
    }
}
