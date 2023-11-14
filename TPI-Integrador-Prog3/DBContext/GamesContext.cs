using Microsoft.EntityFrameworkCore;
using TPI_Integrador_Prog3.Entities;

namespace TPI_Integrador_Prog3.DBContexts
{
    public class GamesContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public GamesContext(DbContextOptions<GamesContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.ClientId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Game)
                .WithMany(g => g.Reviews)
                .HasForeignKey(r => r.GameId);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Reviews)
                .WithOne(r => r.Game)
                .HasForeignKey(g => g.GameId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Games)
                .WithMany(g => g.Clients)
                .UsingEntity(j => j.ToTable("ClientGames"));

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Reviews)
                .WithOne(r => r.Client)
                .HasForeignKey(r => r.ClientId);

            base.OnModelCreating(modelBuilder);
        }
                

                
    }
    

}