using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogProject.Data;
using BlogProject.Data.Entities;

namespace BlogProject.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly BlogProject.Data.ApplicationDbContext _context;

        public CreateModel(BlogProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BlogEId"] = new SelectList(_context.Blogs, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public PostE PostE { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Posts.Add(PostE);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
