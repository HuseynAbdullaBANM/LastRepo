using Bhosphor_Ecoshop.Data.Cart;
using Bhosphor_Ecoshop.Data.Services;
using Bhosphor_Ecoshop.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bhosphor_Ecoshop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly Wishlist _wishlist;

        public OrdersController(IProductsService productsService, Wishlist wishlist)
        {
            _productsService = productsService;
            _wishlist = wishlist;
        }

        public IActionResult Wishlist()
        {
            var items = _wishlist.GetWishlistItems();
            _wishlist.WishlistItems = items;

            var response = new WishlistVM()
            {
                Wishlist = _wishlist,
                WishlistTotal = _wishlist.GetWishlistTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToWishlist(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);

            if (item != null)
            {
                _wishlist.AddItemToWishlist(item);
            }
            return RedirectToAction(nameof(Wishlist));
        }

        public async Task<IActionResult> RemoveItemFromWishlist(int id)
        {
            var item = await _productsService.GetProductByIdAsync(id);

            if (item != null)
            {
                _wishlist.RemoveItemFromWishlist(item);
            }
            return RedirectToAction(nameof(Wishlist));
        }


    }
}
