using Microsoft.EntityFrameworkCore;
using UserRegistration.Domain.Entities;

namespace UserRegistration.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<PhoneOtp> PhoneOtps { get; set; }
        public DbSet<EmailOtp> EmailOtps { get; set; }
    }
}
