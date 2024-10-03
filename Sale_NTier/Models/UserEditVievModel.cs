using System.ComponentModel.DataAnnotations;

namespace Sale_NTier.Models
{
    public class UserEditVievModel
    {
        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter the Mail address")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Please choose your gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter a Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter agin Password")]
        [Compare("Password", ErrorMessage = "Passwords not match")]
        public string ConfirmPassword { get; set; }
    }
}
