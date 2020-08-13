using HomeShop.API.Business;
using HomeShop.API.Data;
using HomeShop.DataAccess.UnitofWork;
using HomeShop.Entity.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HomeShop.Tests.Business
{
    [TestClass]
    public class ProductManagerTest
    {
        Mock<IUnitOfWork> _mockUnitOfWork;
        ProductManager productManager;
        ProductDetailDto productDetailDto;
        Mock<IProductRepository> _mockProductRepository;


        [TestInitialize]
        public void TestIntialize()
        {
            productDetailDto = new ProductDetailDto()
            {
                CategoryId = 1,
                Description = "ddd",
                Discount = 2,
                Id = 1,
                Name = "tt"
            };
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockProductRepository = new Mock<IProductRepository>();
            _mockProductRepository.Setup(m => m.GetProduct(2)).ReturnsAsync(productDetailDto);
            _mockUnitOfWork.Setup(m => m.ProductRepository).Returns(_mockProductRepository.Object);
        }

        [TestMethod]
        public void GetProduct_WhenSuccessfull_ReturnProductDetail()
        {
           
            productManager = new ProductManager(_mockUnitOfWork.Object);

            var productObject =  productManager.GetProduct(2);
            Assert.AreEqual("tt", productObject.Result.Name);
        }
    }
}
