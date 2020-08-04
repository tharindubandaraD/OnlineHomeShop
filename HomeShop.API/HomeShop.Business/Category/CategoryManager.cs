using HomeShop.API.Data.CategoryRepository;
using HomeShop.DataAccess.UnitofWork;
using HomeShop.Entity.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShop.API.Business.Category
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>Gets the category.</summary>
        /// <returns></returns>
        async Task<IEnumerable<CategoryForDetailDto>> ICategoryManager.GetCategory()
        {
            return  await _unitOfWork.CategoryRepository.GetCategory();            
        }
    }
}