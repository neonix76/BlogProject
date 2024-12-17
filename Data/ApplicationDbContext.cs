using BlogProject.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostE>()
                .HasOne(p => p.BlogE)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.BlogEId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PostE> Posts { get; set; }
        public DbSet<BlogE> Blogs { get; set; }
    }
}
