using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sale_NTier.Models;
using System.Threading.Tasks;

namespace Sale_NTier.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditVievModel userEditVievModel = new UserEditVievModel();
            userEditVievModel.Name = values.Name;
            userEditVievModel.Surname = values.Surname;
            userEditVievModel.Mail = values.Email;
            userEditVievModel.Gender = values.Gender;

            return View(userEditVievModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditVievModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Mail;
            user.Gender = model.Gender;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                //Error Messages
            }
            return View();
        }
    }
}
