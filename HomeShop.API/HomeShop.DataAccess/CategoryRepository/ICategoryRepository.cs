using HomeShop.Entity.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HomeShop.API.Data.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryForDetailDto>> GetCategory();
    }
}