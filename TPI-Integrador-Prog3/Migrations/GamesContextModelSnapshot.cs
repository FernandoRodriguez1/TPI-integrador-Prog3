﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TPI_Integrador_Prog3.DBContexts;

#nullable disable

namespace TPI_Integrador_Prog3.Migrations
{
    [DbContext(typeof(GamesContext))]
    partial class GamesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("AdminGames", b =>
                {
                    b.Property<int>("AdminsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AdminsId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("AdminGames", (string)null);

                    b.HasData(
                        new
                        {
                            AdminsId = 4,
                            GamesId = 1
                        },
                        new
                        {
                            AdminsId = 5,
                            GamesId = 1
                        });
                });

            modelBuilder.Entity("ClientGames", b =>
                {
                    b.Property<int>("ClientsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClientsId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("ClientsGames", (string)null);

                    b.HasData(
                        new
                        {
                            ClientsId = 1,
                            GamesId = 1
                        },
                        new
                        {
                            ClientsId = 2,
                            GamesId = 1
                        },
                        new
                        {
                            ClientsId = 3,
                            GamesId = 1
                        });
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Developer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GameRating")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReviewId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comments = "En resident evil 4, al agente especial Leon S. Kennedy se le asigna la misión de rescatar a la hija del presidente de los EUA, que ha sido secuestrada. Tras llegar a una aldea rural europea, se enfrenta a nuevas amenazas que suponen retos totalmente diferentes de los clásicos enemigos zombis de pesados movimientos de las primeras entregas de esta serie. Leon lucha contra terroríficas criaturas nuevas infestadas con una nueva amenaza denominada «Las Plagas» y se enfrenta a una agresiva horda de enemigos que incluye aldeanos bajo control mental conectados a Los Iluminados, la misteriosa secta detrás del rapto.",
                            DepartureDate = new DateTime(2005, 1, 5, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Developer = "Capcon",
                            GameName = "Resident Evil 4(2005)",
                            GameRating = 95,
                            Gender = "Accion",
                            LastUpdate = new DateTime(2014, 1, 5, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Synopsis = ""
                        });
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdminId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatorClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("CreatorClientId");

                    b.HasIndex("GameId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Admin", b =>
                {
                    b.HasBaseType("TPI_Integrador_Prog3.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Email = "Fernando@gmail.com",
                            Password = "123456",
                            UserName = "Fer"
                        },
                        new
                        {
                            Id = 5,
                            Email = "Nico@gmail.com",
                            Password = "123456",
                            UserName = "Micki"
                        });
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Client", b =>
                {
                    b.HasBaseType("TPI_Integrador_Prog3.Entities.User");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Fernando@gmail.com",
                            Password = "123456",
                            UserName = "Fer"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Nico@gmail.com",
                            Password = "123456",
                            UserName = "Micki"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Augusto@gmail.com",
                            Password = "123456",
                            UserName = "Augusto"
                        });
                });

            modelBuilder.Entity("AdminGames", b =>
                {
                    b.HasOne("TPI_Integrador_Prog3.Entities.Admin", null)
                        .WithMany()
                        .HasForeignKey("AdminsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPI_Integrador_Prog3.Entities.Games", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClientGames", b =>
                {
                    b.HasOne("TPI_Integrador_Prog3.Entities.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPI_Integrador_Prog3.Entities.Games", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Games", b =>
                {
                    b.HasOne("TPI_Integrador_Prog3.Entities.Review", null)
                        .WithMany("Games")
                        .HasForeignKey("ReviewId");
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Review", b =>
                {
                    b.HasOne("TPI_Integrador_Prog3.Entities.Admin", "Admin")
                        .WithMany("Reviews")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPI_Integrador_Prog3.Entities.Client", "Client")
                        .WithMany("Reviews")
                        .HasForeignKey("CreatorClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPI_Integrador_Prog3.Entities.Games", "NameGame")
                        .WithMany("Reviews")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Client");

                    b.Navigation("NameGame");
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Games", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Review", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Admin", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Client", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
