﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Contestant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Contestants");
                });

            modelBuilder.Entity("Domain.Entities.ContestantGame", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ContestantId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("GameId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ContestantId");

                    b.HasIndex("GameId");

                    b.ToTable("ContestantGames");
                });

            modelBuilder.Entity("Domain.Entities.Game", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("EndedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GameStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Domain.Entities.Score", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("ContestantId")
                        .HasColumnType("longtext");

                    b.Property<string>("GameId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("Domain.Entities.ContestantGame", b =>
                {
                    b.HasOne("Domain.Entities.Contestant", "Contestant")
                        .WithMany("ContestantGames")
                        .HasForeignKey("ContestantId");

                    b.HasOne("Domain.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.HasOne("Domain.Entities.Game", null)
                        .WithMany("ContestantGames")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contestant");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Domain.Entities.Score", b =>
                {
                    b.HasOne("Domain.Entities.Contestant", "Contestant")
                        .WithMany("Scores")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contestant");
                });

            modelBuilder.Entity("Domain.Entities.Contestant", b =>
                {
                    b.Navigation("ContestantGames");

                    b.Navigation("Scores");
                });

            modelBuilder.Entity("Domain.Entities.Game", b =>
                {
                    b.Navigation("ContestantGames");
                });
#pragma warning restore 612, 618
        }
    }
}
