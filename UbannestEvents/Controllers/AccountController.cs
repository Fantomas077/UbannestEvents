using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UbannestEvents.Models;
using UbannestEvents.ViewModels;

namespace UbannestEvents.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;


                
            
        }

        public async Task<IActionResult> Register(string returnurl = null)
        {
            // Crée les rôles uniquement s'ils n'existent pas
           if(!await _roleManager.RoleExistsAsync("Admin"))
           {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

           }
               
       





            returnurl ??= Url.Content("~/");

            var obj = new RegisterVM
            {
               
                ReturnUrl = returnurl,
                RoleLIst = _roleManager.Roles.Select(role => new SelectListItem
                {
                    Text = role.Name,
                    Value = role.Name
                }).ToList()
            };

            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult>Register (RegisterVM registerVM)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName=registerVM.Email,
                    FullName=registerVM.Name,
                    Email=registerVM.Email,
                    CreatedDate=DateTime.Now,
                    EmailConfirmed = true



                };
                var result = await _userManager.CreateAsync(user, registerVM.Password);
                await _signInManager.SignInAsync(user, isPersistent: false);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, registerVM.SelectedRole);
                    if (!string.IsNullOrEmpty(registerVM.ReturnUrl) && Url.IsLocalUrl(registerVM.ReturnUrl))
                    {
                        return Redirect(registerVM.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            registerVM.RoleLIst = _roleManager.Roles.Select(role => new SelectListItem
            {
                Text = role.Name,
                Value = role.Name
            }).ToList();
            return View(registerVM);

        }
        [HttpGet]
       
        public IActionResult Login(string returnurl = null)
        {
            returnurl ??= Url.Content("~/"); // ✅ Ne remplace que si null
            var obj = new LoginVM { ReturnUrl = returnurl };
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginVM.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberME, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        // Rediriger selon le rôle, SANS tenir compte du ReturnUrl si Admin
                        if (await _userManager.IsInRoleAsync(user, "Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }

                        // Pour les autres utilisateurs (Customer), utiliser ReturnUrl si défini
                        if (await _userManager.IsInRoleAsync(user, "Customer"))
                        {
                            if (!string.IsNullOrEmpty(loginVM.ReturnUrl) && Url.IsLocalUrl(loginVM.ReturnUrl))
                            {
                                return Redirect(loginVM.ReturnUrl);
                            }

                            return RedirectToAction("Index", "Home");
                        }

                        // Fallback générique
                        return RedirectToAction("Index", "Home");
                    }

                }

                // Email ou mot de passe incorrect
                ModelState.AddModelError(string.Empty, "Email ou mot de passe invalide.");
            }

            return View(loginVM);
        }


       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
