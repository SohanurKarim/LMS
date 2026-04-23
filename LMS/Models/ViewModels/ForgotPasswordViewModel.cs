using System.ComponentModel.DataAnnotations;

namespace LMS.Models.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        [Display(Name = "Email Id")]
        public string Email { get; set; }
    }
}
