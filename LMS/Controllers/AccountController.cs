using EmailSender.Helper;
using LMS.Models;
using LMS.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace LMS.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //******Below code for Register*******
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User u = new User()
                {
                    Name = model.Name,
                    Email = model.Email,
                    UserName = model.Email,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };
                try
                {
                    var res = await _userManager.CreateAsync(u, model.Password);
                    if (res.Succeeded)
                    {
                        // Here Send Welcome Email
                        EmailHelper emailHelper = new EmailHelper();
                        string subject = "Welcome to our website!";
                        string message = $"Dear {model.Name},<br><br>Thank you for registering on our website! We are excited to have you as a member of our community.<br>Your User Id: " + model.Email + "<br>Your Password Id: " + model.Password + "<br><br>Best regards,<br><font color='blue'> SFDW Team";
                        emailHelper.SendEmail(model.Email, subject, message);
                        ////Here Assign Role
                        await _userManager.AddToRoleAsync(u, model.Role.ToString()); // Instructor / Student
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var item in res.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while creating the user: " + ex.Message);

                }
            }
            return View(model);
        }
        //******Below code for Login*******
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (res.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                   
                    //// 2. Create claims (THIS IS YOUR CODE)
                    //var claims = new List<Claim>
                    //{
                    //    new Claim(ClaimTypes.Name, user.Name),
                    //    new Claim(ClaimTypes.Role, user.Role) // Student / Instructor
                    //};

                    //var identity = new ClaimsIdentity(claims, "login");
                    //var principal = new ClaimsPrincipal(identity);

                    //await HttpContext.SignInAsync(principal);

                    if (user != null)
                    {

                        if (await _userManager.IsInRoleAsync(user, "Instructor"))
                            return RedirectToAction("Instructor", "Dashboard");

                        if (await _userManager.IsInRoleAsync(user, "Student"))
                            return RedirectToAction("Student", "Dashboard");
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            return View(model);
        }
        //******Below code for Logout*******
        public async Task<IActionResult> Logout()
        {
          if(_signInManager.IsSignedIn(User))
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Login");
            }
            return NotFound();

        }
        //******Below code for Change password*******
        public async Task<IActionResult> ChangePassword()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == _userManager.GetUserName(User));
                if (user != null)
                {
                    TempData["Email"] = user.UserName;
                }
                return View();
            }
            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == _userManager.GetUserName(User));
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    var res = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                    if (res.Succeeded)
                    {
                        await _signInManager.SignOutAsync();
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var item in res.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
            if(User != null)
            {                
                if (user != null)
                {
                    TempData["Email"] = user.UserName;
                }
            }
            return View(model);
        }
        //******Below code for Forget password*******
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        public async Task SendForgotPasswordEmail(string? email, User? user)
        {
            // Generate a password reset token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Create a password reset link
            var resetLink = Url.Action("ResetPassword", "Login", new { email = email, token = token }, protocol:HttpContext.Request.Scheme);
            
            // Encode the link to prevent XSS attacks
            //var encodedLink = System.Net.WebUtility.HtmlEncode(resetLink);
            var safeLink = HtmlEncoder.Default.Encode(resetLink);

            // Create the email subject and message
            string subject = "Reset Your Password";

            // Craft HTML message body
            var message = $@"
                <div style=""font-family: Arial, Helvetica, sans-serif; font-size: 16px; color: #333; line-height: 1.5; padding: 20px;"">
                    <h2 style=""color: #007bff; text-align: center;"">Password Reset Request</h2>
                    <p style=""margin-bottom: 20px;"">Hi {user.Name} ,</p>
    
                    <p>We received a request to reset your password for your <strong>SFDW</strong> account. If you made this request, please click the button below to reset your password:</p>
    
                    <div style=""text-align: center; margin: 20px 0;"">
                        <a href=""{safeLink}"" 
                           style=""background-color: #007bff; color: #fff; padding: 10px 20px; text-decoration: none; font-weight: bold; border-radius: 5px; display: inline-block;"">
                            Reset Password
                        </a>
                    </div>
    
                    <p>If the button above doesn’t work, copy and paste the following URL into your browser:</p>
                    <p style=""background-color: #f8f9fa; padding: 10px; border: 1px solid #ddd; border-radius: 5px;"">
                        <a href=""{safeLink}"" style=""color: #007bff; text-decoration: none;"">{safeLink}</a>
                    </p>
    
                    <p>If you did not request to reset your password, please ignore this email or contact support if you have concerns.</p>
    
                    <p style=""margin-top: 30px;"">Thank you,<br />SFDW</p>
                </div>";


            // Create the email message with the reset link
            if (user != null)
            {
                //string message = $"Dear {user.Name},<br><br>We received a request to reset your password. Please click the link below to reset your password:<br><a href='{safeLink}'>Reset Password</a><br><br>If you did not request a password reset, please ignore this email.<br><br>Best regards,<br><font color='blue'> SFDW Team";
                EmailHelper emailHelper = new EmailHelper();
                emailHelper.SendEmail(email, subject, message);
            }

        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
                if (ModelState.IsValid)
                {
                    // Attempt to find a user in the database whose email address matches the one entered by the user.
                    //var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    // If a user is found
                    if (user != null)
                    {
                        await SendForgotPasswordEmail(model.Email, user);
                        ViewBag.Message = "Password reset link has been sent to your email.";
                        return RedirectToAction("ForgotPasswordConfirmation");
                    }
                    else
                    {
                        // If the user was not found, we still redirect to "ForgotPasswordConfirmation" without revealing that the email does not exist.
                        // This approach helps prevent account enumeration and brute force attacks.
                        ViewBag.Message = "No user found with this email.";
                        return RedirectToAction("ForgotPassword","Login");
                        //ModelState.AddModelError("", "No user found with this email.");
                        //return View(model);
                    }
                }
                return View(model);
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string email, string token)
        {
            //if password reset token or eamil is null, most likely the 
            //user tried to tamper the password reset link
            if (token == null || email == null)
            {
                ViewBag.ErrorTitle = "Invalid password reset link.";
                ViewBag.ErrorMessage = "The password reset link is invalid or has expired. Please request a new password reset link.";
                return View("Error");
            }
            else
            {
                //var model = new ResetPasswordViewModel { Email = email, Token = token }; or
                //ResetPasswordViewModel model = new ResetPasswordViewModel()
                //{
                //    Email = email,
                //    Token = token
                //}; or
                ResetPasswordViewModel model = new ResetPasswordViewModel();
                model.Email = email;
                model.Token = token;
                return View(model);

            }
        }
        [HttpPost]        
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    return RedirectToAction("ResetPasswordConfirmation");
                }
            }
            return View(model);
        }
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }


    }
}
