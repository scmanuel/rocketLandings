using FluentAssertions;
using Moq;
using System;
using Xunit;
using Zartis.RocketLanding.Contracts;
using Zartis.RocketLanding.Models;
using Zartis.RocketLanding.TestSupport;

namespace Zartis.RocketLanding.UnitTests.Models.LandingAreaTests
{
    public static class ConstructorTests
    {
        public sealed class Given_Valid_Dependencies_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private LandingArea _sut;
            private IDimension _areaDimension;
            private ILandingPlatform _platform;
            private IApproachCheckResultMapper _approachCheckResultMapper;

            protected override void Given()
            {
                const int areaDimensionX = 100;
                const int areaDimensionY = 100;
                const int platformDimensionX = 50;
                const int platformDimensionY = 50;

                _areaDimension = new Dimension(areaDimensionX, areaDimensionY);

                var landingStrategy = Mock.Of<ILandingStrategy>();
                var platformDimension = new Dimension(platformDimensionX, platformDimensionY);
                _platform = new LandingPlatform(platformDimension, landingStrategy);

                _approachCheckResultMapper = Mock.Of<IApproachCheckResultMapper>();
            }

            protected override void When()
            {
                _sut = new LandingArea(_areaDimension, _platform, _approachCheckResultMapper);
            }

            [Fact]
            public void Then_It_Should_Have_Created_A_Valid_Instance()
            {
                _sut.Should().NotBeNull();
            }

            [Fact]
            public void Then_It_Should_Be_An_ILandingArea()
            {
                _sut.Should().BeAssignableTo<ILandingArea>();
            }
        }

        public sealed class Given_Missing_Area_Dimension_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private LandingArea _sut;
            private IDimension _areaDimension;
            private ILandingPlatform _platform;
            private IApproachCheckResultMapper _approachCheckResultMapper;
            private Exception _expectedException;

            protected override void Given()
            {
                const int platformDimensionX = 50;
                const int platformDimensionY = 50;

                _areaDimension = default(IDimension);

                var landingStrategy = Mock.Of<ILandingStrategy>();
                var platformDimension = new Dimension(platformDimensionX, platformDimensionY);
                _platform = new LandingPlatform(platformDimension, landingStrategy);

                _approachCheckResultMapper = Mock.Of<IApproachCheckResultMapper>();
            }

            protected override void When()
            {
                _expectedException = Record.Exception(
                    () => _sut = new LandingArea(_areaDimension, _platform, _approachCheckResultMapper));
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

        public sealed class Given_Missing_Landing_Platform_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private LandingArea _sut;
            private IDimension _areaDimension;
            private ILandingPlatform _platform;
            private IApproachCheckResultMapper _approachCheckResultMapper;
            private Exception _expectedException;

            protected override void Given()
            {
                const int areaDimensionX = 100;
                const int areaDimensionY = 100;

                _areaDimension = new Dimension(areaDimensionX, areaDimensionY);
                _platform = default(ILandingPlatform);
                _approachCheckResultMapper = Mock.Of<IApproachCheckResultMapper>();
            }

            protected override void When()
            {
                _expectedException = Record.Exception(
                    () => _sut = new LandingArea(_areaDimension, _platform, _approachCheckResultMapper));
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

        public sealed class Given_Missing_Approach_Check_Result_Mapper_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private LandingArea _sut;
            private IDimension _areaDimension;
            private ILandingPlatform _platform;
            private IApproachCheckResultMapper _approachCheckResultMapper;
            private Exception _expectedException;

            protected override void Given()
            {
                const int areaDimensionX = 100;
                const int areaDimensionY = 100;
                const int platformDimensionX = 50;
                const int platformDimensionY = 50;

                _areaDimension = new Dimension(areaDimensionX, areaDimensionY);

                var landingStrategy = Mock.Of<ILandingStrategy>();
                var platformDimension = new Dimension(platformDimensionX, platformDimensionY);
                _platform = new LandingPlatform(platformDimension, landingStrategy);

                _approachCheckResultMapper = default(IApproachCheckResultMapper);
            }

            protected override void When()
            {
                _expectedException = Record.Exception(
                    () => _sut = new LandingArea(_areaDimension, _platform, _approachCheckResultMapper));
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

        public sealed class Given_Landing_Platform_Out_Of_Landing_Area_When_Constructing_Instance
            : Given_When_Then_Test
        {
            private LandingArea _sut;
            private IDimension _areaDimension;
            private ILandingPlatform _platform;
            private IApproachCheckResultMapper _approachCheckResultMapper;
            private Exception _expectedException;

            protected override void Given()
            {
                const int areaDimensionX = 10;
                const int areaDimensionY = 20;
                const int platformDimensionX = 40;
                const int platformDimensionY = 50;

                _areaDimension = new Dimension(areaDimensionX, areaDimensionY);

                var landingStrategy = Mock.Of<ILandingStrategy>();
                var platformDimension = new Dimension(platformDimensionX, platformDimensionY);
                _platform = new LandingPlatform(platformDimension, landingStrategy);

                _approachCheckResultMapper = Mock.Of<IApproachCheckResultMapper>();
            }

            protected override void When()
            {
                _expectedException = Record.Exception(
                    () => _sut = new LandingArea(_areaDimension, _platform, _approachCheckResultMapper));
            }

            [Fact]
            public void Then_It_Should_Not_Create_An_Instance()
            {
                _sut.Should().BeNull();
            }

            [Fact]
            public void Then_It_Should_Throw_An_ArgumentOutOfRangeException()
            {
                _expectedException.Should().BeAssignableTo<ArgumentOutOfRangeException>();
            }
        }
    }
}
