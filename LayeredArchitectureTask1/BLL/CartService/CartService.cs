using LayeredArchitectureTask1.DAL.CartService;

namespace LayeredArchitectureTask1.BLL.CartService
{
    public class CartService : ICartService
    {
        private readonly CartRepository _cartRepository;

        public CartService()
        {
            _cartRepository = new CartRepository();
        }

        //GEt list of cart Items from DAL
        public List<CartItemDto> GetAllCartItems()
        {
            var cartItems = _cartRepository.GetAllCartItems();

            return cartItems.Select(i => new CartItemDto
            {
                Id = i.Id,
                ItemId = i.ItemId,
                Name = i.Name,
                ImageUrl = i.ImageUrl,
                ImageAltText = i.ImageAltText,
                Price = i.Price,
                Quantity = i.Quantity
            }).ToList();
        }

        //Add item to the cart
        public void AddItemToCart(CartItemDto cartItemDto)
        {
            var item = new CartItem
            {
                ItemId = cartItemDto.ItemId,
                Name = cartItemDto.Name,
                ImageUrl = cartItemDto.ImageUrl,
                ImageAltText = cartItemDto.ImageAltText,
                Price = cartItemDto.Price,
                Quantity = cartItemDto.Quantity
            };

            _cartRepository.AddItemToCart(item);
        }

        //Remove item from the cart
        public void RemoveCartItem(int id)
        {
            _cartRepository.RemoveCartItem(id);
        }

    }
}
