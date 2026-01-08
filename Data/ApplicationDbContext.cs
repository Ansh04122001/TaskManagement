using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TaskManagement.Models;

namespace TaskManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbSet<TaskItem> Tasks { get; set; }
        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddAuditInfo()
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "System";

            foreach (var entry in ChangeTracker.Entries<TaskItem>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = DateTime.Now;
                    entry.Entity.LastUpdatedOn = DateTime.Now;
                    entry.Entity.CreatedBy = userName;
                    entry.Entity.LastUpdatedBy = userName;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastUpdatedOn = DateTime.Now;
                    entry.Entity.LastUpdatedBy = userName;
                }
            }
        }

    }
}




