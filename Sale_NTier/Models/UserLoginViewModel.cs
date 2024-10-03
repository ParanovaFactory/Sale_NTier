using System.ComponentModel.DataAnnotations;

namespace Sale_NTier.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
    }
}
