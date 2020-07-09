using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HomeShop.API.Data;
using HomeShop.API.Dtos;
using HomeShop.API.Model;

namespace HomeShop.API.Business
{
    public class ProductBusinessLayer : IProductBusinessLayer
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductBusinessLayer(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<ProductDetailDto> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            var productDetail = _mapper.Map<ProductDetailDto>(product);
            return productDetail;
        }

        public async Task<IEnumerable<ProductDetailDto>> GetProductbyCategory(int id)
        {
           var productbyCategory = await _productRepository.GetProductbyCategory(id);
         //  var productbyCategoryDetail = _mapper.Map<ProductDetailDto>(productbyCategory);
           return productbyCategory;
        }

        public async Task<IEnumerable<ProductListDto>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            var prdoctsList = _mapper.Map<IEnumerable<ProductListDto>>(products);
            return prdoctsList;
        }
    }
}