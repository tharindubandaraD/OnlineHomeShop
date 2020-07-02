using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShop.API.Model;


namespace HomeShop.API.Data.CategoryRepository
{
    public interface ICategoryRepository
    {
         Task<IEnumerable<Category>> GetCategory();
    }
}