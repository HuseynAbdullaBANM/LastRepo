using Bhosphor_Ecoshop.Data.Base;
using Bhosphor_Ecoshop.Data.ViewModels;
using Bhosphor_Ecoshop.Models;
using Microsoft.EntityFrameworkCore;

namespace Bhosphor_Ecoshop.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CategoryId = data.CategoryId,
                StartDate = data.StartDate,
                SellerId = data.SellerId
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products
                .Include(c => c.Category)
                .Include(s => s.Seller)
                .FirstOrDefaultAsync(n => n.Id == id);

            return productDetails;
        }

        public async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM()
            {
                Categories = await _context.Categories.OrderBy(n => n.Name).ToListAsync(),
                Sellers = await _context.Sellers.OrderBy(n => n.FirstName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProduct != null)
            {
                dbProduct.Name = data.Name;
                dbProduct.Description = data.Description;
                dbProduct.Price = data.Price;
                dbProduct.ImageURL = data.ImageURL;
                dbProduct.CategoryId = data.CategoryId;
                dbProduct.StartDate = data.StartDate;
                dbProduct.SellerId = data.SellerId;
                await _context.SaveChangesAsync();
            }
      
            await _context.SaveChangesAsync();
        }

    }
}
