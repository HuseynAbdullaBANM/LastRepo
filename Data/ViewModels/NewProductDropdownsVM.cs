using Bhosphor_Ecoshop.Models;

namespace Bhosphor_Ecoshop.Data.ViewModels
{
    public class NewProductDropdownsVM
    {
        public NewProductDropdownsVM()
        {
            Sellers = new List<Seller>();
            Categories = new List<Category>();
        }

        public List<Seller> Sellers { get; set; }
        public List<Category> Categories { get; set; }
    }
}
