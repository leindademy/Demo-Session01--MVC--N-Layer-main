using System.ComponentModel.DataAnnotations;

namespace Company.Presention_Layer.Models
{
   public class ForgetPasswordViewModel
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }
}
}
