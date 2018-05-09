using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GuestBook.Models;
using GuestBook.Data.Infrastructure.Interfaces;

namespace GuestBook.Data.Infrastructure.Logic
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IStorage
    {
        public DbSet<Comment> Comments { get; set; }

        public DbSet<EvaluationComment> EvaluationComments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
