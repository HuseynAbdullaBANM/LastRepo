using Bhosphor_Ecoshop.Data.Base;
using Bhosphor_Ecoshop.Models;

namespace Bhosphor_Ecoshop.Data.Services
{
    public class SellersService : EntityBaseRepository<Seller>, ISellersService
    {
        public SellersService(AppDbContext context) : base(context)
        {

        }
    }
}
