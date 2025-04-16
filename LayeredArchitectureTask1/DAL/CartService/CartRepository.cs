using LiteDB;

namespace LayeredArchitectureTask1.DAL.CartService
{
    public class CartRepository
    {
        private readonly List<CartItem> _cartItems = new List<CartItem>();

        // Get all items from the cart
        public List<CartItem> GetAllCartItems()
        {
            using (var db = new LiteDatabase(@"C:\Users\Public\CartServiceDB.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var collection = db.GetCollection<CartItem>("cartItems");

                return collection.Query().ToList();
            }
        }

        // Add item to the cart
        public void AddItemToCart(CartItem item)
        {
            using (var db = new LiteDatabase(@"C:\Users\Public\CartServiceDB.db"))
            {
                var collection = db.GetCollection<CartItem>("cartItems");

                // Add new cart item, Id will be auto-incremented
                collection.Insert(item);
            }


            //var existingItem = _cartItems.Find(i => i.Id == item.Id);
            //if (existingItem != null)
            //{
            //    existingItem.Quantity += item.Quantity;
            //}
            //else
            //{
            //    _cartItems.Add(item);
            //}
        }

        // Remove item from the cart
        public void RemoveCartItem(int id)
        {
            using (var db = new LiteDatabase(@"C:\Users\Public\CartServiceDB.db"))
            {
                var collection = db.GetCollection<CartItem>("cartItems");
                collection.Delete(id);
            }
        }

        public void DBTransaction(string flag)
        {


        }
        
    }
}
