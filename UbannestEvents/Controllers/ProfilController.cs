using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UbannestEvents.Models;
using UbannestEvents.ViewModels;


namespace UbannestEvents.Controllers
{
    public class ProfilController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManager;
        public ProfilController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpGet]
        public async Task <IActionResult>Edit(string userid)
        {
            var user= await _userManager.GetUserAsync(User);
            if(user.Id!=userid)
            {
                return NotFound();
            }
            return View  (user);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null || user.Id != model.Id)
            {
                return NotFound();
            }

            // Mise à jour des champs modifiables
            user.FullName = model.FullName;
            
            user.Email = model.Email;
          

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["Success"] = "Profil mis à jour avec succès.";
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string userid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.Id != userid)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                await _signManager.SignOutAsync(); ; // Déconnecter l'utilisateur après suppression
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Changepassword()
        {
            return View();
        }
        [HttpPost]
        public async  Task <IActionResult> Changepassword( ResetPasswordVM ResetVM)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
           
             var IsPasswordValid= await _userManager.CheckPasswordAsync(user,ResetVM.CurrentPassword);

            if(!IsPasswordValid)
            {
                ModelState.AddModelError("CurrentPassword", "CurrentPassword und Ihr Password Stimmen nicht");
                return View (ResetVM);
            }
            var result = await _userManager.ChangePasswordAsync(user, ResetVM.CurrentPassword, ResetVM.NewPassword);
            if (result.Succeeded)
            {
                
                return RedirectToAction("Login", "Account");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(ResetVM);

        }
    }
}
