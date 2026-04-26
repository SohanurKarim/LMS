using System.ComponentModel.DataAnnotations;

namespace LMS.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please Enter Email")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email")]
        [Display(Name = "Email Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(40,MinimumLength =8,ErrorMessage ="The {0} must be {2} and at max {1} character long.")]
        [Compare("ConfirmPassword", ErrorMessage ="Password does not match.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Select Role")]
        public string Role { get; set; } // Instructor / Student
    }
}

