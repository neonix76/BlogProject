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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>().Property(z => z.Text).HasMaxLength(150);

            builder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Test",
                    Text = "Test text",
                    Date = DateTime.Now,
                }
                );

            base.OnModelCreating(builder);
        }

        public DbSet<Post> Posts { get; set; }
    }
}
