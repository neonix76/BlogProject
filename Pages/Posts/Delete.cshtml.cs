using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogProject.Data;
using BlogProject.Data.Entities;

namespace BlogProject.Pages.Posts
{
    public class DeleteModel : PageModel
    {
        private readonly BlogProject.Data.ApplicationDbContext _context;

        public DeleteModel(BlogProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PostE PostE { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poste = await _context.Posts.FirstOrDefaultAsync(m => m.Id == id);

            if (poste is not null)
            {
                PostE = poste;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poste = await _context.Posts.FindAsync(id);
            if (poste != null)
            {
                PostE = poste;
                _context.Posts.Remove(PostE);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
