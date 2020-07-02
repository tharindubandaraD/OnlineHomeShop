using System.Collections.Generic;
using System.Threading.Tasks;
using HomeShop.API.Model;

namespace HomeShop.API.Data.BrandRepository
{
    public interface IBrandRepository
    {
         Task<IEnumerable<Brand>> getBrands();
    }
}