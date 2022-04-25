using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bhosphor_Ecoshop.Models
{
    public class WishlistItem
    {
        [Key]
        public int Id { get; set; }

        public Product Product { get; set; }
        public int Amount { get; set; }


        public string WishlistId { get; set; }
    }
}
