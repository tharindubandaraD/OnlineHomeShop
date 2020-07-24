using HomeShop.Entity.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShop.API.Business
{
    public interface IProductManager
    {
        Task<ProductDetailDto> GetProduct(int id);
        Task<IEnumerable<ProductListDto>> GetProducts();
        Task<IEnumerable<ProductDetailDto>> GetProductbyCategory(int id);
    }
}