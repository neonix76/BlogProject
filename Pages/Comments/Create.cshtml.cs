using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogProject.Data;
using BlogProject.Data.Entities;

namespace BlogProject.Pages.Comments
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
            return Page();
        }

        [BindProperty]
        public CommentaryE CommentaryE { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comments.Add(CommentaryE);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
