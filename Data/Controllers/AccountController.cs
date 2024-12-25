using BlogProject.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

public class AccountController : Controller
{
    //private readonly UserManager<ApplicationUser> _userManager;
    //private readonly RoleManager<IdentityRole> _roleManager;

    //public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    //{
    //    _userManager = userManager;
    //    _roleManager = roleManager;
    //}

    //[HttpPost]
    //[Authorize] // Убедитесь, что пользователь авторизован
    //public async Task<IActionResult> AddRoleToUser(string roleName)
    //{
    //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    //    var user = await _userManager.FindByIdAsync(userId);

    //    if (user == null)
    //    {
    //        return NotFound("Пользователь не найден.");
    //    }

    //    // Проверяем, существует ли роль
    //    var roleExists = await _roleManager.RoleExistsAsync(roleName);
    //    if (!roleExists)
    //    {
    //        await _roleManager.CreateAsync(new IdentityRole(roleName));
    //    }

    //    // Добавляем пользователя в роль
    //    var result = await _userManager.AddToRoleAsync(user, roleName);
    //    if (result.Succeeded)
    //    {
    //        return Ok("Роль успешно добавлена.");
    //    }
    //    else
    //    {
    //        foreach (var error in result.Errors)
    //        {
    //            Console.WriteLine(error.Description);
    //        }
    //        return BadRequest("Не удалось добавить роль к пользователю.");
    //    }
    //}
}