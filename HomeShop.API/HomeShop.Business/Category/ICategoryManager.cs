using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShop.Entity.Dtos;

namespace HomeShop.API.Business.Category
{
    public interface ICategoryManager
    {
         Task<IEnumerable<CategoryForDetailDto>> GetCategory();
    }
}