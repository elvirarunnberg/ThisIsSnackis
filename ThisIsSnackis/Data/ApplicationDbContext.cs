using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ThisIsSnackis.Models.Category> Category { get; set; } = default!;
        public DbSet<ThisIsSnackis.Models.Comment> Comment { get; set; } = default!;
        public DbSet<ThisIsSnackis.Models.Message> Message { get; set; } = default!;
        public DbSet<ThisIsSnackis.Models.Post> Post { get; set; } = default!;
        public DbSet<ThisIsSnackis.Models.Report> Report { get; set; } = default!;
        public DbSet<ThisIsSnackis.Models.UserPicture> UserPicture { get; set; } = default!;
        public DbSet<ThisIsSnackis.Models.Header> Header { get; set; } = default!;

    }
}
