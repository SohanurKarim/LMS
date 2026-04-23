using System.ComponentModel.DataAnnotations;

namespace LMS.Models.ViewModels
{
    public class ChangePasswordViewModel
    {

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        [Display(Name = "Email Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Current Password")]
        //[StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be {2} and at max {1} character long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Please Enter New Password")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be {2} and at max {1} character long.")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
