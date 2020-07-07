using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HomeShop.API.Dtos;
using HomeShop.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace HomeShop.API.Data.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public CategoryRepository(DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<CategoryForDetailDto>> GetCategory()
        {
          //  var Categories = await _dataContext.Categories.Include(p => p.Products).ToListAsync();    
            
            var Categories = await  (from c in _dataContext.Categories join
                                 p in _dataContext.Products on  c.CategoryID equals p.CategoryId 
                                    join pt in _dataContext.Photos on p.Id equals pt.ProductId 
                                    where pt.IsMain == true 
                                    select new CategoryForDetailDto()
                                    {
                                        CategoryName = c.Name,
                                        ProductName = p.Name,
                                        PhotoUrl = pt.Url,
                                        Price = p.Price
                                        
                                    }).ToListAsync();


            return Categories;
        }
    } 
}