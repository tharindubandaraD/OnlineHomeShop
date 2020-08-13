using AutoMapper;
using HomeShop.API.Data;
using HomeShop.API.Data.BrandRepository;
using HomeShop.API.Data.CategoryRepository;
using HomeShop.API.Data.OrderProductRepository;
using HomeShop.API.Data.OrderRepository;
using Microsoft.EntityFrameworkCore;

namespace HomeShop.DataAccess.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        private IOrderRepository _orderRepository;
        private IOrderProductRepository _orderProductRepository;
        private IProductRepository _productRepository;
        private IAuthRepository _authRepository;
        private ICategoryRepository _categoryRepository;
        private IBrandRepository _brandRepository;

        public UnitOfWork(DataContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IOrderRepository OrderRepository
        {
            get { return _orderRepository = _orderRepository ?? new OrderRepository(_dbContext,_mapper); }
        }

        public IOrderProductRepository OrderProductRepository
        {
            get { return _orderProductRepository = _orderProductRepository ?? new OrderProductRepository(_dbContext,_mapper); }
        }

        public IProductRepository ProductRepository
        {
            get { return _productRepository = _productRepository ?? new ProductRepository(_dbContext, _mapper); }
        }
        public IAuthRepository AuthRepository
        {
            get { return _authRepository = _authRepository ?? new AuthRepository(_dbContext, _mapper); }
        }
        public ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository = _categoryRepository ?? new CategoryRepository(_dbContext); }
        }
        public IBrandRepository BrandRepository
        {
            get { return _brandRepository = _brandRepository ?? new BrandRepository(_dbContext); }
        }

        public void Commit()
        {
            _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            _dbContext.DisposeAsync();
        }
    }
}
