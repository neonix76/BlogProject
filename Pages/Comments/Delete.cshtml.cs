using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogProject.Data;
using BlogProject.Data.Entities;

namespace BlogProject.Pages.Comments
{
    public class DeleteModel : PageModel
    {
        private readonly BlogProject.Data.ApplicationDbContext _context;

        public DeleteModel(BlogProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CommentaryE CommentaryE { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentarye = await _context.Comments.FirstOrDefaultAsync(m => m.Id == id);

            if (commentarye is not null)
            {
                CommentaryE = commentarye;

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

            var commentarye = await _context.Comments.FindAsync(id);
            if (commentarye != null)
            {
                CommentaryE = commentarye;
                _context.Comments.Remove(CommentaryE);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
