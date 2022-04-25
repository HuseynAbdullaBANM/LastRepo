using Bhosphor_Ecoshop.Data.Base;
using Bhosphor_Ecoshop.Models;

namespace Bhosphor_Ecoshop.Data.Services
{
    public class CategoriesService : EntityBaseRepository<Category>, ICategoriesService
    {
        public CategoriesService(AppDbContext context) : base(context)
        {


        }
    }
}
