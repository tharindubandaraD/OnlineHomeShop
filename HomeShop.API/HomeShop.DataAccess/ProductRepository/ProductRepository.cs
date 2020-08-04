using AutoMapper;
using HomeShop.DataAccess.Model;
using HomeShop.Entity.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeShop.API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>Adds the specified entity.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        /// <summary>Deletes the specified entity.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        /// <summary>Gets the product.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ProductDetailDto> GetProduct(int id)
        {
            var product = await _context.Products.Include(p => p.Photos).FirstOrDefaultAsync(i => i.Id == id);
            return _mapper.Map<ProductDetailDto>(product);
        }

        /// <summary>Gets the products.</summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductListDto>> GetProducts()
        {
            var products = await _context.Products.Include(p => p.Photos).ToListAsync();
            return _mapper.Map<ProductListDto[]>(products);            
        }
              

        /// <summary>Gets the productby category.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductDetailDto>> GetProductbyCategory(int id)
        {
            var products = await (from category in _context.Categories
                                  join
                                    product in _context.Products on category.CategoryID equals product.CategoryId
                                  join photo in _context.Photos on product.Id equals photo.ProductId
                                  where photo.IsMain && product.CategoryId == id
                                  select new ProductDetailDto()
                                  {
                                      Id = product.Id,
                                      CategoryId = product.CategoryId,
                                      Quantity = product.Quantity,
                                      Name = product.Name,
                                      Discount = product.Discount,
                                      Description = product.Description,
                                      Price = product.Price,
                                      PhotoUrl = photo.Url

                                  }).ToListAsync();
            return products;
        }
    }
}