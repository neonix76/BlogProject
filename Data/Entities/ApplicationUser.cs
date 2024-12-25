using Microsoft.AspNetCore.Identity;

namespace BlogProject.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[]? Picture { get; set; }
        public string? Role { get; set; }
    }
}
