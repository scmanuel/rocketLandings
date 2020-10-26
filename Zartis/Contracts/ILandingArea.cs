using System;

namespace Zartis.RocketLanding.Contracts
{
    public interface ILandingArea
    {
        string CheckApproach(Guid rocketId, IPosition position);
    }
}
