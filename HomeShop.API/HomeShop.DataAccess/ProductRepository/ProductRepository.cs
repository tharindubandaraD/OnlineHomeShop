using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeShop.Entity.Dtos;
using HomeShop.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace HomeShop.API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.Include(p => p.Photos).FirstOrDefaultAsync(i => i.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _context.Products.Include(p => p.Photos).ToListAsync();
            return products;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ProductDetailDto>> GetProductbyCategory(int id)
        {
            var products = await  (from category in _context.Categories join
                                 product in _context.Products on  category.CategoryID equals product.CategoryId
                                  join photo in _context.Photos on  product.Id equals photo.ProductId                                    
                                    where photo.IsMain == true &&  product.CategoryId == id
                                    select new ProductDetailDto()
                                    {    
                                        Id = product.Id,                                   
                                        CategoryId= product.CategoryId,
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