using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShop.API.Dtos;
using HomeShop.API.Model;

namespace HomeShop.API.Business
{
    public interface IProductBusinessLayer
    {
           Task<ProductDetailDto> GetProduct(int id);
           Task<IEnumerable<ProductListDto>> GetProducts();
           Task <IEnumerable<ProductDetailDto>> GetProductbyCategory(int id);
    }
}