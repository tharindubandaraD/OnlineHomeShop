using HomeShop.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShop.API.Data.BrandRepository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly DataContext _context;
        public BrandRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> getBrands()
        {
            var getBrands = await _context.Brands.Include(p => p.Products).ToListAsync();
            return getBrands;
        }
    }
}