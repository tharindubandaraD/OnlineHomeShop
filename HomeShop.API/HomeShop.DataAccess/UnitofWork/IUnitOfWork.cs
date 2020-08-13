using HomeShop.API.Data;
using HomeShop.API.Data.BrandRepository;
using HomeShop.API.Data.CategoryRepository;
using HomeShop.API.Data.OrderProductRepository;
using HomeShop.API.Data.OrderRepository;

namespace HomeShop.DataAccess.UnitofWork
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        IOrderProductRepository OrderProductRepository { get;  }
        IProductRepository ProductRepository { get;  }
        IAuthRepository AuthRepository { get;  }
        ICategoryRepository CategoryRepository { get; }
        IBrandRepository BrandRepository { get; }
        void Commit();
        void Rollback();
    }
}
