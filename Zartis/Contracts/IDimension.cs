namespace Zartis.RocketLanding.Contracts
{
    public interface IDimension
    {
        bool Contains(IDimension area);
        bool Contains(IPosition position);
        int GetDimensionX();
        int GetDimensionY();
        int GetOffsetX();
        int GetOffsetY();
    }
}
