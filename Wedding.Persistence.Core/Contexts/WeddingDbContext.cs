using Microsoft.EntityFrameworkCore;
using Wedding.Domain.Core.Invites;
using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Persistence.Core.Contexts
{
    public class WeddingDbContext : DbContext
    {
        public DbSet<Invite> Invites { get; set; }
        
        public DbSet<WeddingEvent> WeddingEvents { get; set; }

        public DbSet<StarterChoice> StarterChoices { get; set; }

        public DbSet<MainChoice> MainChoices { get; set; }

        public DbSet<DessertChoice> DessertChoices { get; set; }

        public WeddingDbContext(DbContextOptions<WeddingDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public override void Dispose()
        {
            SaveChanges();
            base.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invite>()
                .ToTable("Invite");

            modelBuilder.Entity<Invite>()
                .ToTable("Invite");

            modelBuilder.Entity<Invitee>()
                .ToTable("Invitee");

            modelBuilder.Entity<InviteWeddingEvent>()
                .ToTable("InviteWeddingEvent");

            modelBuilder.Entity<Meal>()
                .ToTable("Meal");
            
            modelBuilder.Entity<Rsvp>()
                .ToTable("Rsvp");

            modelBuilder.Entity<ReferenceData>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<WeddingEvent>("WeddingEvent");

            modelBuilder.Entity<ExtendedReferenceData>()
                .ToTable("ReferenceData")
                .HasDiscriminator<string>("Discriminator")
                .HasValue<StarterChoice>("StarterChoice")
                .HasValue<MainChoice>("MainChoice")
                .HasValue<DessertChoice>("DessertChoice");
            
            base.OnModelCreating(modelBuilder);
        }
    }
}