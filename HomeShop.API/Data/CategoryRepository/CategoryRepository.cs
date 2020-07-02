using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HomeShop.API.Dtos;
using HomeShop.API.Model;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IEnumerable<Category>> GetCategory()
        {
            var Categories = await _dataContext.Categories.Include(p => p.Products).ToListAsync();
            return Categories;
        }
    }
}