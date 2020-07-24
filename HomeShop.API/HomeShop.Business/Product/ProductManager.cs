using AutoMapper;
using HomeShop.API.Data;
using HomeShop.Entity.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeShop.API.Business
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        /// <summary>Gets the product.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ProductDetailDto> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            var productDetail = _mapper.Map<ProductDetailDto>(product);
            return productDetail;
        }

        /// <summary>Gets the productby category.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductDetailDto>> GetProductbyCategory(int id)
        {
            var productbyCategory = await _productRepository.GetProductbyCategory(id);
            return productbyCategory;
        }

        /// <summary>Gets the products.</summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductListDto>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            var prdoctsList = _mapper.Map<IEnumerable<ProductListDto>>(products);
            return prdoctsList;
        }
    }
}