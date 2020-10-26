using System;
using Zartis.RocketLanding.Contracts;

namespace Zartis.RocketLanding.Models
{
    public class Rocket
        : IRocket
    {
        private readonly Guid _id;
        private readonly ILandingArea _area;

        public Rocket(ILandingArea area)
        {
            _area =
                area
                ?? throw new ArgumentNullException(nameof(area));

            _id = Guid.NewGuid();
        }

        public string CheckApproach(int positionX, int positionY)
        {
            var position = new Position(positionX, positionY);
            var approachCheckResult = _area.CheckApproach(_id, position);
            
            return approachCheckResult;
        }
    }
}
