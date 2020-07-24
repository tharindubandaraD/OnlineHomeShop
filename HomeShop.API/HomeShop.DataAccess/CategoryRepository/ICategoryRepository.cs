using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShop.Entity.Dtos;


namespace HomeShop.API.Data.CategoryRepository
{
    public interface ICategoryRepository
    {
         Task<IEnumerable<CategoryForDetailDto>> GetCategory();       
    }
}