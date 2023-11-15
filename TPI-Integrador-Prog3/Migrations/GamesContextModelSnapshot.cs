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

            modelBuilder.Entity("ClientGame", b =>
                {
                    b.Property<int>("ClientsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClientsId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("ClientGames", (string)null);
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DepartureDate")
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

                    b.Property<int?>("ReviewId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

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

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("UserType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Admin", b =>
                {
                    b.HasBaseType("TPI_Integrador_Prog3.Entities.User");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Client", b =>
                {
                    b.HasBaseType("TPI_Integrador_Prog3.Entities.User");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("ClientGame", b =>
                {
                    b.HasOne("TPI_Integrador_Prog3.Entities.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPI_Integrador_Prog3.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Game", b =>
                {
                    b.HasOne("TPI_Integrador_Prog3.Entities.Review", null)
                        .WithMany("Games")
                        .HasForeignKey("ReviewId");
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Review", b =>
                {
                    b.HasOne("TPI_Integrador_Prog3.Entities.Client", "Client")
                        .WithMany("Reviews")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPI_Integrador_Prog3.Entities.Game", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Game", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Review", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("TPI_Integrador_Prog3.Entities.Client", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
