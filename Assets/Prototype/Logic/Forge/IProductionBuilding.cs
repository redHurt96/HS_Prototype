namespace Prototype.Logic.Forge
{
    public interface IProductionBuilding
    {
        bool CanCraft();
        void PerformCraft();
    }
}