using Microsoft.EntityFrameworkCore;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Models;

namespace TPI_Integrador_Prog3.DBContexts
{
    public class GamesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Games> Games { get; set; }

        public GamesContext(DbContextOptions<GamesContext> dbContextOptions) : base(dbContextOptions) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<Client>().HasData(

                new Client
                {
                    UserName = "Fer",
                    Email = "Fernando@gmail.com",
                    Password = "123456",
                    Id = 1
                },
                new Client
                {
                    UserName = "Micki",
                    Email = "Nico@gmail.com",
                    Password = "123456",
                    Id = 2
                },
                new Client
                {
                    
                    UserName = "Augusto",
                    Email = "Augusto@gmail.com",
                    Password = "123456",
                    Id = 3
                });

            modelBuilder.Entity<Admin>().HasData(
               new Admin
               {

                   UserName = "Fer",
                   Email = "Fernando@gmail.com",
                   Password = "123456",
                   Id = 4
               },
               new Admin
               {
                   UserName = "Micki",
                   Email = "Nico@gmail.com",
                   Password = "123456",
                   Id = 5
               });
            modelBuilder.Entity<Games>().HasData(
            new Games
            {
                Id = 1,
                GameName = "Resident Evil 4(2005)",
                Gender = "Accion",
                Synopsis = "",
                GameRating = 95,
                DepartureDate = new DateTime(2005, 1, 5, 12, 0, 0),
                Developer = "Capcon",
                Comments = "En resident evil 4, al agente especial Leon S. Kennedy" +
                " se le asigna la misión de rescatar a la hija del presidente de los EUA," +
                " que ha sido secuestrada. Tras llegar a una aldea rural europea," +
                " se enfrenta a nuevas amenazas que suponen retos totalmente diferentes" +
                " de los clásicos enemigos zombis de pesados movimientos" +
                " de las primeras entregas de esta serie." +
                " Leon lucha contra terroríficas criaturas nuevas infestadas" +
                " con una nueva amenaza denominada «Las Plagas»" +
                " y se enfrenta a una agresiva horda de enemigos que incluye" +
                " aldeanos bajo control mental conectados a Los Iluminados," +
                " la misteriosa secta detrás del rapto.",
                LastUpdate = new DateTime(2014, 1, 5, 12, 0, 0)
            });
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id= 1,
                    Title = "Un Juegazo",
                    Description = "Juegazo",
                    CreationDate = new DateTime(2005, 1, 8, 15, 35, 0),
                }
                );
            modelBuilder.Entity<Games>()
               .HasMany(g => g.Clients)
               .WithMany(g => g.Games)
               .UsingEntity(j => j
                   .ToTable("ClientesGames")
                   .HasData(new[]
                       {
                            new { ClientId = 1, GameId = 1},
                            new { ClientId= 2, GameId = 1},
                            new { ClientId= 3, GameId = 1}
                       }
                   ));
            modelBuilder.Entity<Games>()
               .HasMany(g => g.Admins)
               .WithMany(a => a.Games)
               .UsingEntity(j => j
                   .ToTable("AdminsGames")
                   .HasData(new[]
                       {
                            new { AdminId = 1, GameId = 1},
                            new { AdminId = 2, GameId = 1},
                       }
                   ));

            //Revisar
            modelBuilder.Entity<Games>()
               .HasMany(g => g.Reviews)
               .WithMany(r => r.Games)
               .UsingEntity(j => j
                   .ToTable("ReviewGamesAttended")
                   .HasData(new[]
                       {
                            new {  ReviewId = 1, GameId = 1},
                       }
                   ));
        }
        
    }
}
