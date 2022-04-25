using Bhosphor_Ecoshop.Data.Base;
using Bhosphor_Ecoshop.Data.ViewModels;
using Bhosphor_Ecoshop.Models;

namespace Bhosphor_Ecoshop.Data.Services
{
    public interface IProductsService : IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<NewProductDropdownsVM> GetNewProductDropdownsValues();
        Task AddNewProductAsync(NewProductVM data);
        Task UpdateProductAsync(NewProductVM data);
    }
}
