using HomeShop.DataAccess.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShop.API.Data.BrandRepository
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetBrands();
    }
}