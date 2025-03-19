using BasketballPlayers.Domain.Common;
using BasketballPlayers.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BasketballPlayers.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Stats> Stats { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {
            
        }
        public ApplicationDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O7O7SSV\\SQLEXPRESS01;Database=BasketballPlayers;Trusted_Connection=true;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Player>()
            .HasOne(p => p.Stats)          
            .WithOne(s => s.Player)        
            .HasForeignKey<Stats>(s => s.PlayerId);
            base.OnModelCreating(builder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<IAuditableEntity>().ToList();
            foreach (var entry in entries)
            {
                var entity = entry.Entity;
                if (EntityState.Added == entry.State)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                else if (EntityState.Modified == entry.State)
                {
                    entity.ModifiedAt = DateTime.UtcNow;
                }
                else if (EntityState.Deleted == entry.State)
                {
                    entry.State = EntityState.Modified;
                    entity.DeletedAt = DateTime.UtcNow;
                    entity.IsDeleted = true;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
