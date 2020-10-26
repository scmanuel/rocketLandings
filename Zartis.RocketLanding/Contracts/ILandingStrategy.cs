using System;
using Zartis.RocketLanding.Enums;

namespace Zartis.RocketLanding.Contracts
{
    public interface ILandingStrategy
    {
        ApproachCheckResult CheckApproach(Guid rocketId, IPosition position, IDimension platformDimension);
    }
}
