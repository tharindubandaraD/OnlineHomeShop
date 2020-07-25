using HomeShop.Entity.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeShop.API.Data.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;
        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<CategoryForDetailDto>> GetCategory()
        {

            var Categories = await (from category in _dataContext.Categories
                                    join
                                    product in _dataContext.Products on category.CategoryID equals product.CategoryId
                                    join photo in _dataContext.Photos on product.Id equals photo.ProductId
                                    where photo.IsMain
                                    select new CategoryForDetailDto()
                                    {
                                        CategotyId = category.CategoryID,
                                        CategoryName = category.Name

                                    }).Distinct().ToListAsync();

            return Categories;
        }




    }
}