namespace LayeredArchitectureTask1.BLL.CartService
{
    public interface ICartService
    {
        List<CartItemDto> GetAllCartItems();

        void AddItemToCart(CartItemDto cartItemDto);

        void RemoveCartItem(int id);
    }
}
