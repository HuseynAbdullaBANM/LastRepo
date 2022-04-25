using Bhosphor_Ecoshop.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Bhosphor_Ecoshop.Data.ViewComponents
{
    public class WishlistSummary : ViewComponent
    {
        private readonly Wishlist _wishlist;
        public WishlistSummary(Wishlist wishlist)
        {
            _wishlist = wishlist;
        }

        public IViewComponentResult Invoke()
        {
            var items = _wishlist.GetWishlistItems();

            return View(items.Count);
        }
    }
}
