using Microsoft.AspNetCore.Mvc;
using Bhosphor_Ecoshop.Data.Services;
using Bhosphor_Ecoshop.Models;
namespace Bhosphor_Ecoshop.Controllers;

public class SellersController : Controller
{
    private readonly ISellersService _service;

    public SellersController(ISellersService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allSellers = await _service.GetAllAsync();
        return View(allSellers);
    }

    //Get request: sellers/details/1
    public async Task<IActionResult> Details(int id)
    {
        var sellerDetails = await _service.GetByIdAsync(id);
        if (sellerDetails == null) return View("NotFound");
        return View(sellerDetails);
    }

    //GET: sellers/create

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("ProfilePictureUrl, FirstName, LastName, Bio")] Seller seller)
    {
        if (!ModelState.IsValid) return View(seller);

        await _service.AddAsync(seller);
        return RedirectToAction(nameof(Index));
    }



    //Get: sellers/edit/1
    public async Task<IActionResult> Edit(int id)
    {
        var sellerDetails = await _service.GetByIdAsync(id);
        if (sellerDetails == null) return View("NotFound");
        return View(sellerDetails);

    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureUrl, FirstName, LastName, Bio")] Seller seller)
    {
        if (!ModelState.IsValid) return View(seller);

        if (id == seller.Id)
        {
            await _service.UpdateAsync(id, seller);
            return RedirectToAction(nameof(Index));
        }
        return View(seller);

    }

    //Get: sellers/delete/1
    public async Task<IActionResult> Delete(int id)
    {
        var sellerDetails = await _service.GetByIdAsync(id);
        if (sellerDetails == null) return View("NotFound");
        return View(sellerDetails);

    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var sellerDetails = await _service.GetByIdAsync(id);
        if (sellerDetails == null) return View("NotFound");

        await _service.DeleteAsync(id);

        return RedirectToAction(nameof(Index));

    }
}
