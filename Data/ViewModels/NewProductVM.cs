using Bhosphor_Ecoshop.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhosphor_Ecoshop.Models
{
    public class NewProductVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [Display(Name ="Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Desciption is required")]
        [Display(Name = "Product Desciption")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price in $")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Product image url is required")]
        [Display(Name = "Product image url")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Product publishment date is required")]
        [Display(Name = "Product publishment date")]
        public DateTime StartDate { get; set; }

        //public ProductCategory ProductCategory { get; set; }

        //Relationships

        //Category
        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Select a category")]
        public int CategoryId { get; set; }

        //Seller
        [Required(ErrorMessage = "Seller is required")]
        [Display(Name = "Select a seller")]
        public int SellerId { get; set; }

    }
}
