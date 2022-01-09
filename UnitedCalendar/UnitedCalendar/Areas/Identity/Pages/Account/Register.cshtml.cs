using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using UnitedCalendar.Models;

namespace UnitedCalendar.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> roleManager;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            this.roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "O Nome é um campo Obrigatório.")]
            public string Nome { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { 
                    UserName = Input.Email, 
                    Email = Input.Email,
                    Nome = Input.Nome
                };

                var escolaEmail = Input.Email.Split("@");
                if (escolaEmail[1].Equals("isec.pt"))
                    user.Escola = "ISEC";
                else if (escolaEmail[1].Equals("esac.pt"))
                    user.Escola = "ESAC";
                else if (escolaEmail[1].Equals("esec.pt"))
                    user.Escola = "ESEC";
                else if (escolaEmail[1].Equals("estgoh.pt"))
                    user.Escola = "ESTGOH";
                else if (escolaEmail[1].Equals("estesc.pt"))
                    user.Escola = "ESTeSC";
                else if (escolaEmail[1].Equals("iscac.pt"))
                    user.Escola = "ISCAC";

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {

                    //Associar Role Default
                    IdentityRole roleEstudante = await roleManager.FindByNameAsync("Estudante");
                    IdentityRole roleAdmin = await roleManager.FindByNameAsync("Admins");
                    IdentityRole roleProf = await roleManager.FindByNameAsync("Professor");
                    IdentityRole roleFunc = await roleManager.FindByNameAsync("Funcionario");

                    if (roleEstudante == null) {
                        IdentityRole role = new IdentityRole
                        {
                            Name = "Estudante"
                        };

                        await roleManager.CreateAsync(role);
                    }

                    if (roleAdmin == null)
                    {
                        IdentityRole role = new IdentityRole
                        {
                            Name = "Admins"
                        };

                        await roleManager.CreateAsync(role);
                    }

                    if (roleProf == null)
                    {
                        IdentityRole role = new IdentityRole
                        {
                            Name = "Professor"
                        };

                        await roleManager.CreateAsync(role);
                    }

                    if (roleFunc == null)
                    {
                        IdentityRole role = new IdentityRole
                        {
                            Name = "Funcionario"
                        };

                        await roleManager.CreateAsync(role);
                    }

                    roleEstudante = await roleManager.FindByNameAsync("Estudante");


                    await _userManager.AddToRoleAsync(user, roleEstudante.Name); //Default Conta Estudante


                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
