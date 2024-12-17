using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogProject.Data;
using BlogProject.Data.Entities;

namespace BlogProject.Pages.Blogs
{
    public class DeleteModel : PageModel
    {
        private readonly BlogProject.Data.ApplicationDbContext _context;

        public DeleteModel(BlogProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlogE BlogE { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloge = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);

            if (bloge is not null)
            {
                BlogE = bloge;

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

            var bloge = await _context.Blogs.FindAsync(id);
            if (bloge != null)
            {
                BlogE = bloge;
                _context.Blogs.Remove(BlogE);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
