using BlogProject.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogProject.Data.Controllers
{
    //public class RoleController : Controller
    //{
    //    private readonly UserManager<ApplicationUser> _userManager;
    //    private readonly RoleManager<IdentityRole> _roleManager;

    //    public RoleController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    //    {
    //        _userManager = userManager;
    //        _roleManager = roleManager;
    //    }

    //    [HttpGet]
    //    public IActionResult AddRole()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> AddRole(RoleModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            // Получаем UserId текущего авторизованного пользователя
    //            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    //            var user = await _userManager.FindByIdAsync(userId);

    //            if (user != null)
    //            {
    //                if (!await _roleManager.RoleExistsAsync(model.RoleName))
    //                {
    //                    await _roleManager.CreateAsync(new IdentityRole(model.RoleName));
    //                }

    //                var result = await _userManager.AddToRoleAsync(user, model.RoleName);
    //                if (result.Succeeded)
    //                {
    //                    return RedirectToAction("Index", "Home"); // или куда вам нужно
    //                }
    //                foreach (var error in result.Errors)
    //                {
    //                    ModelState.AddModelError(string.Empty, error.Description);
    //                }
    //            }
    //            else
    //            {
    //                ModelState.AddModelError(string.Empty, "Пользователь не найден.");
    //            }
    //        }
    //        return View(model);
    //    }
    //}
}
