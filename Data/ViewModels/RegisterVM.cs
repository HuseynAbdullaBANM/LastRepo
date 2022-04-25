using System.ComponentModel.DataAnnotations;

namespace Bhosphor_Ecoshop.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Only Alphabets allowed.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [Display(Name = "Second Name")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Only Alphabets allowed.")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [Display(Name = "Location")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Only Alphabets allowed.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [Display(Name = "Email Address")]
        [RegularExpression("([A-Za-z0-9]\\.?)+[^\\.]+@([A-Za-z0-9]+\\.?)+[^\\.]", ErrorMessage = "Enter the valid email address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [Display(Name = "Phone Number")]
        [RegularExpression("(\\+994|0)[0-9]{9}", ErrorMessage = "Enter the valid Azerbaijani number and do not use space")]
        public string PhoneNumber { get; set; }

        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirming password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
