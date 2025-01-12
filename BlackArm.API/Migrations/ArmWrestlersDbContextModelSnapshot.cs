﻿// <auto-generated />
using System;
using BlackArm.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlackArm.API.Migrations
{
    [DbContext(typeof(ArmWrestlersDbContext))]
    partial class ArmWrestlersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlackArm.Domain.Models.ArmWrestler", b =>
                {
                    b.Property<Guid>("ArmWrestlerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Bicep")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("Forearm")
                        .HasColumnType("integer");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("Losses")
                        .HasColumnType("integer");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.Property<int>("Wins")
                        .HasColumnType("integer");

                    b.HasKey("ArmWrestlerId");

                    b.ToTable("ArmWrestler");

                    b.HasData(
                        new
                        {
                            ArmWrestlerId = new Guid("7bb4f59c-dadc-4918-a215-730dd34f03d4"),
                            Bicep = 40,
                            BirthDate = new DateTimeOffset(new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Country = "US",
                            FirstName = "nick",
                            Forearm = 30,
                            Height = 120,
                            LastName = "piterson",
                            Losses = 2,
                            NickName = "qwerty",
                            Weight = 150,
                            Wins = 15
                        },
                        new
                        {
                            ArmWrestlerId = new Guid("2d1b391c-92c9-416e-93f8-74ab4fd2a818"),
                            Bicep = 40,
                            BirthDate = new DateTimeOffset(new DateTime(2022, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Country = "US",
                            FirstName = "john",
                            Forearm = 30,
                            Height = 120,
                            LastName = "doe",
                            Losses = 2,
                            NickName = "poop",
                            Weight = 150,
                            Wins = 15
                        });
                });

            modelBuilder.Entity("BlackArm.Domain.Models.Competition", b =>
                {
                    b.Property<Guid>("CompetitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CompetitionDate")
                        .HasColumnType("date");

                    b.Property<string>("CompetitionName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("CompetitionId");

                    b.ToTable("Competition");
                });

            modelBuilder.Entity("BlackArm.Domain.Models.Fight", b =>
                {
                    b.Property<Guid>("FightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompetitionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WinnerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Wrestler1Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Wrestler2Id")
                        .HasColumnType("uuid");

                    b.HasKey("FightId");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("WinnerId");

                    b.HasIndex("Wrestler1Id");

                    b.HasIndex("Wrestler2Id");

                    b.ToTable("Fight");
                });

            modelBuilder.Entity("BlackArm.Domain.Models.RadarGraph", b =>
                {
                    b.Property<Guid>("GraphId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AngleStrenght")
                        .HasColumnType("integer");

                    b.Property<int>("PronatorStrength")
                        .HasColumnType("integer");

                    b.Property<int>("SidePressure")
                        .HasColumnType("integer");

                    b.Property<int>("Stamina")
                        .HasColumnType("integer");

                    b.Property<Guid>("WrestlerId")
                        .HasColumnType("uuid");

                    b.Property<int>("WristStrength")
                        .HasColumnType("integer");

                    b.HasKey("GraphId");

                    b.HasIndex("WrestlerId")
                        .IsUnique();

                    b.ToTable("RadarGraph");
                });

            modelBuilder.Entity("BlackArm.Domain.Models.Round", b =>
                {
                    b.Property<Guid>("RoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("FightId")
                        .HasColumnType("uuid");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("integer");

                    b.Property<Guid>("StyleUsedId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WinnerId")
                        .HasColumnType("uuid");

                    b.HasKey("RoundId");

                    b.HasIndex("FightId");

                    b.HasIndex("StyleUsedId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("BlackArm.Domain.Models.WrestlingStyle", b =>
                {
                    b.Property<Guid>("StyleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("StyleName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("StyleId");

                    b.ToTable("WrestlingStyle");
                });

            modelBuilder.Entity("BlackArm.Domain.Models.Fight", b =>
                {
                    b.HasOne("BlackArm.Domain.Models.Competition", "Competition")
                        .WithMany("Fights")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlackArm.Domain.Models.ArmWrestler", "Winner")
                        .WithMany("FightsWon")
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlackArm.Domain.Models.ArmWrestler", "Wrestler1")
                        .WithMany("FightsAsWrestler1")
                        .HasForeignKey("Wrestler1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlackArm.Domain.Models.ArmWrestler", "Wrestler2")
                        .WithMany("FightsAsWrestler2")
                        .HasForeignKey("Wrestler2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("Winner");

                    b.Navigation("Wrestler1");

                    b.Navigation("Wrestler2");
                });

            modelBuilder.Entity("BlackArm.Domain.Models.RadarGraph", b =>
                {
                    b.HasOne("BlackArm.Domain.Models.ArmWrestler", "Wrestler")
                        .WithOne("RadarGraph")
                        .HasForeignKey("BlackArm.Domain.Models.RadarGraph", "WrestlerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wrestler");
                });

            modelBuilder.Entity("BlackArm.Domain.Models.Round", b =>
                {
                    b.HasOne("BlackArm.Domain.Models.Fight", "Fight")
                        .WithMany("Rounds")
                        .HasForeignKey("FightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlackArm.Domain.Models.WrestlingStyle", "StyleUsed")
                        .WithMany("RoundsUsedIn")
                        .HasForeignKey("StyleUsedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlackArm.Domain.Models.ArmWrestler", "Winner")
                        .WithMany("RoundsWon")
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fight");

                    b.Navigation("StyleUsed");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("BlackArm.Domain.Models.ArmWrestler", b =>
                {
                    b.Navigation("FightsAsWrestler1");

                    b.Navigation("FightsAsWrestler2");

                    b.Navigation("FightsWon");

                    b.Navigation("RadarGraph")
                        .IsRequired();

                    b.Navigation("RoundsWon");
                });

            modelBuilder.Entity("BlackArm.Domain.Models.Competition", b =>
                {
                    b.Navigation("Fights");
                });

            modelBuilder.Entity("BlackArm.Domain.Models.Fight", b =>
                {
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("BlackArm.Domain.Models.WrestlingStyle", b =>
                {
                    b.Navigation("RoundsUsedIn");
                });
#pragma warning restore 612, 618
        }
    }
}
