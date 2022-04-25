using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Bhosphor_Ecoshop.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Second Name")]
        public string SecondName { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}
