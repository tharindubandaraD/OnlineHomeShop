using HomeShop.Entity.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShop.API.Business.Category
{
    public interface ICategoryManager
    {
        Task<IEnumerable<CategoryForDetailDto>> GetCategory();
    }
}