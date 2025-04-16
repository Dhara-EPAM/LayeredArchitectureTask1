using AutoMapper;
using LayeredArchitectureTask1.BLL.CartService;
using LayeredArchitectureTask1.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace LayeredArchitectureTask1.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var _cartItems = _cartService.GetAllCartItems();
            var cartItems = _cartItems.Select(i => new CartItem
            {
                Id = i.Id,
                ItemId = i.ItemId,
                Name = i.Name,
                ImageUrl = i.ImageUrl,
                ImageAltText = i.ImageAltText,
                Price = i.Price,
                Quantity = i.Quantity
            }).ToList();

            return View(cartItems);
        }

        // HTTP GET
        public IActionResult AddItemToCart()
        {
            return View();
        }

        // HTTP POST  
        [HttpPost]
        public IActionResult AddItemToCart(CartItem cartItem)
        {
            var _cartItem =
               _mapper.Map<BLL.CartService.CartItemDto>(cartItem);
            
           _cartService.AddItemToCart(_cartItem);

            return View("Thanks");
        }

        public IActionResult Delete(int id)
        {
            _cartService.RemoveCartItem(id);

            return View("Thanks");
        }

    }
}
