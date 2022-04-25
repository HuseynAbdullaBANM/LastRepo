using Bhosphor_Ecoshop.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhosphor_Ecoshop.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }

        //public ProductCategory ProductCategory { get; set; }

        //Relationships

        //Category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        //Seller
        public int SellerId { get; set; }
        [ForeignKey("SellerId")]
        public Seller? Seller { get; set; }

    }
}
