using HomeShop.API.Business;
using HomeShop.API.Data;
using HomeShop.DataAccess.UnitofWork;
using HomeShop.Entity.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace HomeShop.Tests.Business
{
    [TestClass]
    public class ProductManagerTest
    {
        ProductManager productManager;
        Mock<IUnitOfWork> _mockUnitOfWork;
        Mock<IProductRepository> _mockProductRepository;

        [TestInitialize]
        public void TestInitialize()
        {

            IEnumerable<ProductListDto> productList = new List<ProductListDto> {

           new  ProductListDto {
                Discount = 2,
                Id = 1,
                Name = "aa"
            },
            new ProductListDto {
                Discount = 2,
                Id = 2,
                Name = "bb"
              }
            };

            IEnumerable<ProductDetailDto> productDetailDtos = new List<ProductDetailDto> {

           new  ProductDetailDto {
                Discount = 2,
                Id = 1,
                Name = "aa"
            },
            new ProductDetailDto {
                Discount = 2,
                Id = 2,
                Name = "bb"
              }
            };


            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockProductRepository = new Mock<IProductRepository>();

            
            _mockUnitOfWork.Setup(m => m.ProductRepository).Returns(_mockProductRepository.Object);
            _mockProductRepository.Setup(m => m.GetProducts()).ReturnsAsync(productList);

            _mockProductRepository.Setup(m => m.GetProduct(1)).ReturnsAsync(new ProductDetailDto {
                CategoryId = 1,
                Description = "aaa",
                Discount = 2,
                Id = 2,
                Name = "tt"
            });

            _mockProductRepository.Setup(m => m.GetProductbyCategory(1)).ReturnsAsync(productDetailDtos);
        }

        [TestMethod]
        public void GetProducts_WhenSuccessfull_ReturnProducts()
        {
            productManager = new ProductManager(_mockUnitOfWork.Object);
            IEnumerable<ProductListDto> products = productManager.GetProducts().GetAwaiter().GetResult();
            Assert.AreEqual("aa", products.ToList()[0].Name);
        }

        [TestMethod]
        public void GetProduct_WhenSuccessfull_ReturnProduct()
        {
            productManager = new ProductManager(_mockUnitOfWork.Object);

            ProductDetailDto productDetailDto = productManager.GetProduct(1).GetAwaiter().GetResult();
            Assert.AreEqual(2, productDetailDto.Discount);
        }

        [TestMethod]
        public void GetProductbyCategory_WhenSuccessfull_ReturnProduct()
        {
            productManager = new ProductManager(_mockUnitOfWork.Object);

            IEnumerable<ProductDetailDto> productDetailDtos = productManager.GetProductbyCategory(1).GetAwaiter().GetResult();
            Assert.AreEqual("aa", productDetailDtos.ToList()[0].Name);

        }
    }
}
