using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repoContext;
        private IDeviceRepository _device;
        private ICategoryRepository _category;
        private IBrandRepository _brand;
        private ISupplierRepository _supplier;
        private ISalesRepository _sales;
        private ICartItemRepository _cartItem;
       


        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IDeviceRepository Device
        {
            get
            {
                if (_device == null)
                {
                    _device = new DeviceRepository(_repoContext);
                }

                return _device;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }

                return _category;
            }
        }

        public IBrandRepository Brand
        {
            get
            {
                if (_brand == null)
                {
                    _brand = new BrandRepository(_repoContext);
                }

                return _brand;
            }
        }

        public ISupplierRepository Supplier
        {
            get
            {
                if (_supplier == null)
                {
                    _supplier = new SupplierRepository(_repoContext);
                }

                return _supplier;
            }
        }

        public ISalesRepository Sales
        {
            get
            {
                if (_sales == null)
                {
                    _sales = new SalesRepository(_repoContext);
                }

                return _sales;
            }
        }

        public ICartItemRepository CartItem
        {
            get
            {
                if (_cartItem == null)
                {
                    _cartItem = new CartItemRepository(_repoContext);
                }

                return _cartItem;
            }
        }

       

        public void SaveAsync() => _repoContext.SaveChanges();
    }
}
