using Bhosphor_Ecoshop.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Bhosphor_Ecoshop.Models
{
    public class Category : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }

        [Display(Name = "Category Description")]
        [Required(ErrorMessage = "Category description is required")]
        public string Description { get; set; }

        //Relationships
        //Product
        public List<Product>? Products { get; set; }
    }
}
