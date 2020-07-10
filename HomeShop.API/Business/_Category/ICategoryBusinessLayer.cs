using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShop.API.Dtos;
using HomeShop.API.Model;

namespace HomeShop.API.Business._Category
{
    public interface ICategoryBusinessLayer
    {
         Task<IEnumerable<CategoryForDetailDto>> GetCategory();
    }
}