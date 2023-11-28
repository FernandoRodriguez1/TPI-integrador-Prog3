using Microsoft.EntityFrameworkCore;
using TPI_Integrador_Prog3.Entities;
using TPI_Integrador_Prog3.Enum;
namespace TPI_Integrador_Prog3.DBContexts
{
    public class GamesContext : DbContext
    {
        public GamesContext(DbContextOptions<GamesContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        //Pasamos nuestra opción de la clase, al constructor de nuestra clase padre (DbContext)
        public DbSet<Admin> Admins { get; set; }
        //Permitimos que nuestra entidad sea consultada y guardada dentro de la base de datos.
        //Se crean las tablas correspondientes a las entidades
        public DbSet<Client> Clients { get; set; }
        public DbSet<Game> Games { get; set; }//Cada DbSet es una tabla nueva en nuestra BASE DE DATOS.
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }

        //Hacemos la sobre escritura en el método OnModelCreating de la clase padre DbContext. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //Utilizamos la clase ModelBuilder, la cual permite crear un modelo para nuestro contexto al sobreescribirlo.
        {

            modelBuilder.Entity<User>()
              .HasDiscriminator<UserType>("UserType")
              .HasValue<Admin>(UserType.Admin)
              .HasValue<Client>(UserType.Client);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.ClientId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Game) // Configura la relación uno a muchos (HasOne) con la entidad Game
                .WithMany(g => g.Reviews)// Configura la relación muchos a uno (WithMany) con la entidad Review
                .HasForeignKey(r => r.GameId);// Configura la clave foránea en la entidad Review

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Reviews)
                .WithOne(r => r.Game)
                .HasForeignKey(g => g.GameId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Games)
                .WithMany(g => g.Clients)
                .UsingEntity(j => j.ToTable("ClientGames")); //Aquí se le dá nombre a la tabla que tendrá la entidad en la base de datos.
            // si no se establece un ToTable, se crea una tabla y obtendra el nombre que definamos en el dbset a la entidad. User/users Review/reviews

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Reviews)
                .WithOne(r => r.Client)
                .HasForeignKey(r => r.ClientId);
            //Acá le decimos al DbContext que implemente el método para crear el modelo, pasándole el modelo que nostros creamos por parámetro
            base.OnModelCreating(modelBuilder);
        }

    }

}