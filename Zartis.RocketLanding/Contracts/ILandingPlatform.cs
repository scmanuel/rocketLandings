using System;
using Zartis.RocketLanding.Enums;

namespace Zartis.RocketLanding.Contracts
{
    public interface ILandingPlatform
    {
        ApproachCheckResult CheckApproach(Guid rocketId, IPosition position);
        IDimension GetDimension();
    }
}
