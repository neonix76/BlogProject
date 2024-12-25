using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogProject.Data;
using BlogProject.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace BlogProject.Pages.Blogs
{

    [Authorize(Roles = "STALIN")]
    public class CreateModel : PageModel
    {
        private readonly BlogProject.Data.ApplicationDbContext _context;

        public CreateModel(BlogProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BlogE BlogE { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Blogs.Add(BlogE);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
