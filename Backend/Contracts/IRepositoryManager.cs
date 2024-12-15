namespace Contracts
{
    public interface IRepositoryManager
    {
        IDeviceRepository Device { get; }
        ICategoryRepository Category { get; }
        IBrandRepository Brand { get; }
        ISupplierRepository Supplier { get; }
        ISalesRepository Sales { get; }
        ICartItemRepository CartItem { get; }

        void SaveAsync();
    }
}
