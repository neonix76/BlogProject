using BlogProject.Data.Entities; // Убедитесь, что у вас есть правильный namespace
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlogProject.Pages
{
    public class AddRoleModel : PageModel
    {
        private readonly ILogger<AddRoleModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddRoleModel(
            ILogger<AddRoleModel> logger,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [BindProperty]
        public string RoleName { get; set; } // Свойство для привязки имени роли

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAddRole()
        {
            if (string.IsNullOrEmpty(RoleName))
            {
                ModelState.AddModelError(string.Empty, "Имя роли не может быть пустым.");
                return Page();
            }

            // Получаем текущего пользователя
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Пользователь не найден.");
                return Page();
            }

            // Проверяем, существует ли роль
            if (!await _roleManager.RoleExistsAsync(RoleName))
            {
                // Если роль не существует, создаем её
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(RoleName));
                if (!roleResult.Succeeded)
                {
                    foreach (var error in roleResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return Page();
                }
            }

            // Добавляем роль пользователю
            var result = await _userManager.AddToRoleAsync(user, RoleName);
            if (result.Succeeded)
            {
                return RedirectToPage("Success"); // Замените на нужную страницу
            }

            // Обработка ошибок
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}