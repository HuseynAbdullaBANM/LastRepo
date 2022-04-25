using Bhosphor_Ecoshop.Data;
using Bhosphor_Ecoshop.Data.Services;
using Bhosphor_Ecoshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Bhosphor_Ecoshop.Controllers;

public class ProductsController : Controller
{
    private readonly IProductsService _service;

    public ProductsController(IProductsService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allProducts = await _service.GetAllAsync(n => n.Category);
        return View(allProducts);
    }

    public async Task<IActionResult> Filter(string searchString)
    {
        var allProducts = await _service.GetAllAsync(n => n.Category);

        if (!string.IsNullOrEmpty(searchString))
        {
            //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

            var filteredResultNew = allProducts.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

            return View("Index", filteredResultNew);
        }

        return View("Index", allProducts);
    }

    //Get : Products/Details/1
    public async Task<IActionResult> Details(int id)
    {
        var productDetails = await _service.GetProductByIdAsync(id);
        return View(productDetails); 
    }

    //GET: Products/Create
    public async Task<IActionResult> Create()
    {
        var productDropdownsData = await _service.GetNewProductDropdownsValues();

        ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "Name");
        ViewBag.Sellers = new SelectList(productDropdownsData.Sellers, "Id", "FirstName");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NewProductVM product)
    {
        if (!ModelState.IsValid)
        {
            var productDropdownsData = await _service.GetNewProductDropdownsValues();

            ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "Name");
            ViewBag.Sellers = new SelectList(productDropdownsData.Sellers, "Id", "FirstName");

            return View(product);
        }

        await _service.AddNewProductAsync(product);
        return RedirectToAction(nameof(Index));
    }

    //GET: Products/Edit/1
    public async Task<IActionResult> Edit(int id)
    {
        var productDetails = await _service.GetProductByIdAsync(id);
        if (productDetails == null) return View("NotFound");

        var response = new NewProductVM()
        {
            Id = productDetails.Id,
            Name = productDetails.Name,
            Description = productDetails.Description,
            Price = productDetails.Price,
            StartDate = productDetails.StartDate,
            ImageURL = productDetails.ImageURL,
            CategoryId = productDetails.CategoryId,
            SellerId = productDetails.SellerId,
        };

        var productDropdownsData = await _service.GetNewProductDropdownsValues();
        ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "Name");
        ViewBag.Sellers = new SelectList(productDropdownsData.Sellers, "Id", "FirstName");
        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, NewProductVM product)
    {
        if (id != product.Id) return View("NotFound");

        if (!ModelState.IsValid)
        {
            var productDropdownsData = await _service.GetNewProductDropdownsValues();

            ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "Name");
            ViewBag.Sellers = new SelectList(productDropdownsData.Sellers, "Id", "FirstName");
            return View(product);
        }

        await _service.UpdateProductAsync(product);
        return RedirectToAction(nameof(Index));
    }

}
