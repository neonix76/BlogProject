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

namespace BlogProject.Pages.Blogs
{
    public class EditModel : PageModel
    {
        private readonly BlogProject.Data.ApplicationDbContext _context;

        public EditModel(BlogProject.Data.ApplicationDbContext context)
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

            var bloge =  await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);
            if (bloge == null)
            {
                return NotFound();
            }
            BlogE = bloge;
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

            _context.Attach(BlogE).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogEExists(BlogE.Id))
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

        private bool BlogEExists(int id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }
    }
}
