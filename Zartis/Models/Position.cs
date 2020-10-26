using Zartis.RocketLanding.Contracts;

namespace Zartis.RocketLanding.Models
{
    public class Position
        : IPosition
    {
        public int PositionX { get; }
        public int PositionY { get; }

        public Position(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
