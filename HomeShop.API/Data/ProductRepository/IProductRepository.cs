using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShop.API.Dtos;
using HomeShop.API.Model;

namespace HomeShop.API.Data
{
    public interface IProductRepository
    {
        //T is an any type - phot/product take entity as it a class
       void Add<T>(T entity) where T: class;

       void Delete<T>(T entity) where T: class;

       Task<bool> SaveAll();

       Task<IEnumerable<Product>> GetProducts();

       Task<Product> GetProduct(int i);

       Task<IEnumerable<ProductDetailDto>> GetProductbyCategory(int i);
    }
}