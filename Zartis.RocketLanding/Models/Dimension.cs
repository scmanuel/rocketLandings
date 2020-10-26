using Zartis.RocketLanding.Contracts;

namespace Zartis.RocketLanding.Models
{
    public class Dimension
        : IDimension
    {
        private readonly int _dimensionX;
        private readonly int _dimensionY;
        private readonly int _offsetX;
        private readonly int _offsetY;

        public Dimension(int dimensionX, int dimensionY, int offsetX = 0, int offsetY = 0)
        {
            _dimensionX = dimensionX;
            _dimensionY = dimensionY;
            _offsetX = offsetX;
            _offsetY = offsetY;
        }

        public bool Contains(IDimension subArea)
        {
            var subAreaOffsetX = subArea.GetOffsetX();
            var subAreaOffsetY = subArea.GetOffsetY();
            var subAreaDimensionX = subArea.GetDimensionX();
            var subAreaDimensionY = subArea.GetDimensionY();

            var isContained = subAreaOffsetX + subAreaDimensionX <= _offsetX + _dimensionX
                              && subAreaOffsetY + subAreaDimensionY <= _offsetY + _dimensionY;

            return isContained;
        }

        public bool Contains(IPosition position)
        {
            var isContained = position.PositionX >= _offsetX 
                              && position.PositionX <= _offsetX + _dimensionX
                              && position.PositionY >= _offsetY 
                              && position.PositionY <= _offsetY + _dimensionY;

            return isContained;
        }

        public int GetDimensionX()
        {
            return _dimensionX;
        }

        public int GetDimensionY()
        {
            return _dimensionY;
        }

        public int GetOffsetX()
        {
            return _offsetX;
        }

        public int GetOffsetY()
        {
            return _offsetY;
        }
    }
}
