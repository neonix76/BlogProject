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

namespace BlogProject.Pages.Posts
{
    public class EditModel : PageModel
    {
        private readonly BlogProject.Data.ApplicationDbContext _context;

        public EditModel(BlogProject.Data.ApplicationDbContext context)
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

            var poste =  await _context.Posts.FirstOrDefaultAsync(m => m.Id == id);
            if (poste == null)
            {
                return NotFound();
            }
            PostE = poste;
           ViewData["BlogEId"] = new SelectList(_context.Blogs, "Id", "Id");
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

            _context.Attach(PostE).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostEExists(PostE.Id))
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

        private bool PostEExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
