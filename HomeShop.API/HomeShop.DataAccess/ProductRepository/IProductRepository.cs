using HomeShop.Entity.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShop.API.Data
{
    public interface IProductRepository
    {
        //T is an any type - phot/product take entity as it a class
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;      

        Task<IEnumerable<ProductListDto>> GetProducts();

        Task<ProductDetailDto> GetProduct(int id);

        Task<IEnumerable<ProductDetailDto>> GetProductbyCategory(int id);
    }
}