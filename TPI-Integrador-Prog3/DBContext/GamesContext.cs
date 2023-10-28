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
            modelBuilder.Entity<Games>()
               .HasMany(g => g.Clients)
               .WithMany(g => g.Games)
               .UsingEntity(j => j
                   .ToTable("ClientsGames")
                   .HasData(new[]
                       {
                            new { ClientsId = 1, GamesId = 1},
                            new { ClientsId= 2, GamesId = 1},
                            new { ClientsId= 3, GamesId = 1}
                       }
                   ));

            modelBuilder.Entity<Games>()
               .HasMany(g => g.Admins)
               .WithMany(a => a.Games)
               .UsingEntity(j => j
                   .ToTable("AdminGames")
                   .HasData(new[]
                       { 
                            new { AdminsId = 4, GamesId = 1},
                            new { AdminsId = 5, GamesId = 1},
                        }
                   ));

            //Revisar
            modelBuilder.Entity<Review>()
                .HasOne(r => r.NameGame)
                .WithMany(g => g.Reviews)
                .HasForeignKey(r => r.GameId);
        }

    }
}
