using CagnotteEntity = global::Cagnotte.Domain.Entites.Cagnotte;
using Cagnotte.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Cagnotte.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CagnotteEntity> Cagnottes { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Participation> Participations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration pour Participation (clé composite)
            modelBuilder.Entity<Participation>()
                .HasKey(p => new { p.CagnotteId, p.ParticipantId });

            // Configuration des relations
            modelBuilder.Entity<Participation>()
                .HasOne(p => p.Cagnotte)
                .WithMany(c => c.Participations)
                .HasForeignKey(p => p.CagnotteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Participation>()
                .HasOne(p => p.Participant)
                .WithMany(p => p.Participations)
                .HasForeignKey(p => p.ParticipantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CagnotteEntity>()
                .HasOne(c => c.Entreprise)
                .WithMany(e => e.cagnottes)
                .HasForeignKey(c => c.EntrepriseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
