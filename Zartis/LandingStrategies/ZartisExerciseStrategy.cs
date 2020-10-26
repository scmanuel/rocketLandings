using System;
using System.Collections.Generic;
using System.Linq;
using Zartis.RocketLanding.Contracts;
using Zartis.RocketLanding.Enums;

namespace Zartis.RocketLanding.LandingStrategies
{
    public class ZartisExerciseStrategy
        : ILandingStrategy
    {
        private readonly Dictionary<Guid, Tuple<int, int>> _checkedPositions;

        public ZartisExerciseStrategy()
        {
            _checkedPositions = new Dictionary<Guid, Tuple<int, int>>();
        }

        public ApproachCheckResult CheckApproach(Guid rocketId, IPosition position, IDimension platformDimension)
        {
            if (position is null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            if (platformDimension is null)
            {
                throw new ArgumentNullException(nameof(platformDimension));
            }

            ApproachCheckResult approachCheckResult;

            if (!platformDimension.Contains(position))
            {
                approachCheckResult = ApproachCheckResult.Out;
            }
            else if (IsPositionAlreadyChecked(rocketId, position) || IsCloseOfAnotherRocket(rocketId, position))
            {
                approachCheckResult = ApproachCheckResult.Clash;
            }
            else
            {
                approachCheckResult = ApproachCheckResult.Ok;
                UpdateCheckedPositions(rocketId, position);
            }

            return approachCheckResult;
        }

        private bool IsCloseOfAnotherRocket(Guid rocketId, IPosition positionToCheck)
        {
            var position = new Tuple<int, int>(positionToCheck.PositionX, positionToCheck.PositionY);
            var closeOfAnotherRocket = _checkedPositions
                .Any(p => p.Key != rocketId
                          && (new Tuple<int, int>(p.Value.Item1, p.Value.Item2 + 1).Equals(position)
                              || new Tuple<int, int>(p.Value.Item1, p.Value.Item2 - 1).Equals(position)
                              || new Tuple<int, int>(p.Value.Item1 - 1, p.Value.Item2).Equals(position)
                              || new Tuple<int, int>(p.Value.Item1 - 1, p.Value.Item2 + 1).Equals(position)
                              || new Tuple<int, int>(p.Value.Item1 - 1, p.Value.Item2 - 1).Equals(position)
                              || new Tuple<int, int>(p.Value.Item1 + 1, p.Value.Item2).Equals(position)
                              || new Tuple<int, int>(p.Value.Item1 + 1, p.Value.Item2 + 1).Equals(position)
                              || new Tuple<int, int>(p.Value.Item1 + 1, p.Value.Item2 - 1).Equals(position)));

            return closeOfAnotherRocket;
        }

        private bool IsPositionAlreadyChecked(Guid rocketId, IPosition positionToCheck)
        {
            var position = new Tuple<int, int>(positionToCheck.PositionX, positionToCheck.PositionY);
            var alreadyPositionCheckedByAnotherRockets = _checkedPositions
                .Any(p => p.Key != rocketId && p.Value.Equals(position));

            return alreadyPositionCheckedByAnotherRockets;
        }

        private void UpdateCheckedPositions(Guid rocketId, IPosition positionToCheck)
        {
            _checkedPositions.Remove(rocketId);
            var positionChecked = new Tuple<int, int>(positionToCheck.PositionX, positionToCheck.PositionY);
            _checkedPositions.Add(rocketId, positionChecked);
        }
    }
}
