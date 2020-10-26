using System;
using Zartis.RocketLanding.Contracts;

namespace Zartis.RocketLanding.Models
{
    public class LandingArea
        : ILandingArea
    {
        private readonly ILandingPlatform _platform;
        private readonly IApproachCheckResultMapper _approachCheckResultMapper;

        public LandingArea (IDimension areaDimension, ILandingPlatform platform, IApproachCheckResultMapper approachCheckResultMapper)
        {
            if (areaDimension is null)
            {
                throw new ArgumentNullException(nameof(areaDimension));
            }

            _platform =
                platform
                ?? throw new ArgumentNullException(nameof(platform));

            _approachCheckResultMapper =
                approachCheckResultMapper
                ?? throw new ArgumentNullException(nameof(approachCheckResultMapper));

            var platformDimension = platform.GetDimension();
            if (!areaDimension.Contains(platformDimension))
            {
                throw new ArgumentOutOfRangeException(nameof(platformDimension));
            }
        }

        public string CheckApproach(Guid rocketId, IPosition position)
        {
            if (position is null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            var approachCheckResult = _platform.CheckApproach(rocketId, position);
            var approachCheckResultMapped = _approachCheckResultMapper.Map(approachCheckResult);

            return approachCheckResultMapped;
        }
    }
}
