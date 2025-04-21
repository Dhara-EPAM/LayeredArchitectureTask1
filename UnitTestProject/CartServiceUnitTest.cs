using AutoMapper;
using LayeredArchitectureTask1.BLL.CartService;
using LayeredArchitectureTask1.Controllers;
using LayeredArchitectureTask1.DAL.CartService;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTestProject
{
    public class CartServiceUnitTest
    {
        private Mock<ICartService> _cartServiceMock;
        private Mock<IMapper> _mapperMock;
        private CartController _controller;

        [SetUp]
        public void SetUp()
        {
            _cartServiceMock = new Mock<ICartService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new CartController(_cartServiceMock.Object, _mapperMock.Object);
        }

        [Test]
        public void GetAllCartItems()
        {
            var cartItemDtos = new List<CartItemDto>
            {
                new CartItemDto { Id = 1, ItemId = 101, Name = "Item1", Price = 10, Quantity = 1, ImageUrl = "url1", ImageAltText = "alt1" },
                new CartItemDto { Id = 2, ItemId = 102, Name = "Item2", Price = 20, Quantity = 2, ImageUrl = "url2", ImageAltText = "alt2" }
            };
            _cartServiceMock.Setup(s => s.GetAllCartItems()).Returns(cartItemDtos);

            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
                
            var model = result.Model as List<LayeredArchitectureTask1.Models.CartItem>;

            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(1, model[0].Id);
            Assert.AreEqual("Item1", model[0].Name);
        }


        [Test]
        public void AddsItemToCartAndReturnsThanksView()
        {
            var cartItem = new LayeredArchitectureTask1.Models.CartItem { Id = 1, ItemId = 101, Name = "Item1", Price = 10, Quantity = 1 };
            var cartItemDto = new CartItemDto { Id = 1, ItemId = 101, Name = "Item1", Price = 10, Quantity = 1 };
            
            _mapperMock.Setup(m => m.Map<CartItemDto>(cartItem)).Returns(cartItemDto);

            var result = _controller.AddItemToCart(cartItem) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Thanks", result.ViewName);
            _cartServiceMock.Verify(s => s.AddItemToCart(cartItemDto), Times.Once);
        }

        [Test]
        public void DeleteItemAndReturnsThanksView()
        {
            var cartItemId = 1;
            var result = _controller.Delete(cartItemId) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Thanks", result.ViewName);
            _cartServiceMock.Verify(s => s.RemoveCartItem(cartItemId), Times.Once);
        }

        [TearDown]
        public void Cleanup()
        {
            _controller.Dispose();
        }
    }
}