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
    public class IndexModel : PageModel
    {
        private readonly BlogProject.Data.ApplicationDbContext _context;

        public IndexModel(BlogProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PostE> PostE { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PostE = await _context.Posts
                .Include(p => p.BlogE).ToListAsync();
        }
    }
}
