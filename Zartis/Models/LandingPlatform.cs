using System;
using Zartis.RocketLanding.Contracts;
using Zartis.RocketLanding.Enums;

namespace Zartis.RocketLanding.Models
{
    public class LandingPlatform
        : ILandingPlatform
    {        
        private readonly IDimension _platformDimension;
        private readonly ILandingStrategy _strategy;

        public LandingPlatform(IDimension platformDimension, ILandingStrategy strategy)
        {
            _platformDimension =
               platformDimension
               ?? throw new ArgumentNullException(nameof(platformDimension));

            _strategy =
                strategy
                ?? throw new ArgumentNullException(nameof(strategy));
        }

        public ApproachCheckResult CheckApproach(Guid rocketId, IPosition position)
        {
            if (position is null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            var approachCheckResult = _strategy.CheckApproach(rocketId, position, _platformDimension);

            return approachCheckResult;
        }

        public IDimension GetDimension()
        {
            return _platformDimension;
        }
    }
}
