using Bhosphor_Ecoshop.Models;
using Microsoft.EntityFrameworkCore;

namespace Bhosphor_Ecoshop.Data.Cart
{
    public class Wishlist
    {
        public AppDbContext _context { get; set; }

        public string WishlistId { get; set; }
        public List<WishlistItem> WishlistItems { get; set; }

        public Wishlist(AppDbContext context)
        {
            _context = context;
        }

        public static Wishlist GetWishlist(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new Wishlist(context) { WishlistId = cartId };
        }

        public void AddItemToWishlist(Product product)
        {
            var WishlistItem = _context.WishlistItems.FirstOrDefault(n => n.Product.Id == product.Id && n.WishlistId == WishlistId);

            if (WishlistItem == null)
            {
                WishlistItem = new WishlistItem()
                {
                    WishlistId = WishlistId,
                    Product = product,
                    Amount = 1
                };

                _context.WishlistItems.Add(WishlistItem);
            }
            else
            {
                WishlistItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromWishlist(Product product)
        {
            var WishlistItem = _context.WishlistItems.FirstOrDefault(n => n.Product.Id == product.Id && n.WishlistId == WishlistId);

            if (WishlistItem != null)
            {
                if (WishlistItem.Amount > 1)
                {
                    WishlistItem.Amount--;
                }
                else
                {
                    _context.WishlistItems.Remove(WishlistItem);
                }
            }
            _context.SaveChanges();
        }

        public List<WishlistItem> GetWishlistItems()
        {
            return WishlistItems ?? (WishlistItems = _context.WishlistItems.Where(n => n.WishlistId == WishlistId).Include(n => n.Product).ToList());
        }

        public double GetWishlistTotal() => _context.WishlistItems.Where(n => n.WishlistId == WishlistId).Select(n => n.Product.Price * n.Amount).Sum();

        public async Task ClearWishlistAsync()
        {
            var items = await _context.WishlistItems.Where(n => n.WishlistId == WishlistId).ToListAsync();
            _context.WishlistItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
