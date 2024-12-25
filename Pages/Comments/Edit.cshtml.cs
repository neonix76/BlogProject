using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogProject.Data;
using BlogProject.Data.Entities;

namespace BlogProject.Pages.Comments
{
    public class EditModel : PageModel
    {
        private readonly BlogProject.Data.ApplicationDbContext _context;

        public EditModel(BlogProject.Data.ApplicationDbContext context)
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

            var commentarye =  await _context.Comments.FirstOrDefaultAsync(m => m.Id == id);
            if (commentarye == null)
            {
                return NotFound();
            }
            CommentaryE = commentarye;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CommentaryE).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentaryEExists(CommentaryE.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CommentaryEExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
