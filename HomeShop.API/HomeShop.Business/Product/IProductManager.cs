using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShop.Entity.Dtos;

namespace HomeShop.API.Business
{
    public interface IProductManager
    {
           Task<ProductDetailDto> GetProduct(int id);
           Task<IEnumerable<ProductListDto>> GetProducts();
           Task <IEnumerable<ProductDetailDto>> GetProductbyCategory(int id);
    }
}