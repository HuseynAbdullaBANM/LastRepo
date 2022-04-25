using Bhosphor_Ecoshop.Data.Services;
using Bhosphor_Ecoshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bhosphor_Ecoshop.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoriesService _service;

    public CategoriesController(ICategoriesService service)
    {
        _service = service;
    }


    public async Task<IActionResult> Index()
    {
        var allCategories = await _service.GetAllAsync();
        return View(allCategories);
    }

    //Get: Categories/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Name, Description")] Category category)
    {
        if (!ModelState.IsValid) return View(category);
        await _service.AddAsync(category);
        return RedirectToAction(nameof(Index));
    }

    //Get: Categories/Details/
    public async Task<IActionResult> Details(int id)
    {
        var cinemaDetails = await _service.GetByIdAsync(id);
        if (cinemaDetails == null) return View("NotFound");
        return View(cinemaDetails);
    }


    //Get: Categories/Edit/

    public async Task<IActionResult> Edit(int id)
    {
        var cinemaDetails = await _service.GetByIdAsync(id);
        if (cinemaDetails == null) return View("NotFound");
        return View(cinemaDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Description")] Category category)
    {
        if (!ModelState.IsValid) return View(category);
        await _service.UpdateAsync(id, category);
        return RedirectToAction(nameof(Index));
    }


    //Get: categories/delete/1
    public async Task<IActionResult> Delete(int id)
    {
        var categoryDetails = await _service.GetByIdAsync(id);
        if (categoryDetails == null) return View("NotFound");
        return View(categoryDetails);

    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var categoryDetails = await _service.GetByIdAsync(id);
        if (categoryDetails == null) return View("NotFound");

        await _service.DeleteAsync(id);

        return RedirectToAction(nameof(Index));

    }

}
