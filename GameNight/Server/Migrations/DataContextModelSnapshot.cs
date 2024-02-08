﻿// <auto-generated />
using System;
using GameNight.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameNight.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameNight.Shared.EntityClasses.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AvarageRatingOfAttended")
                        .HasColumnType("int");

                    b.Property<int?>("BestMaxPlayers")
                        .HasColumnType("int");

                    b.Property<int?>("BestMinPlayers")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GameComplexity")
                        .HasColumnType("int");

                    b.Property<int?>("GameLength")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("int");

                    b.Property<int>("MinPlayers")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<bool>("Retired")
                        .HasColumnType("bit");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameNight.Shared.EntityClasses.Logg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfEvent")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DictatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DictatorId");

                    b.ToTable("Loggs");
                });

            modelBuilder.Entity("GameNight.Shared.EntityClasses.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Attending")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DictatorPrecentage")
                        .HasColumnType("float");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDictator")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Retired")
                        .HasColumnType("bit");

                    b.Property<double>("TimesAttended")
                        .HasColumnType("float");

                    b.Property<double>("TimesDictator")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("GameNight.Shared.EntityClasses.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("GameRating")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("GameNight.Shared.EntityClasses.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LoggId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoggId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("GameNight.Shared.EntityClasses.Game", b =>
                {
                    b.HasOne("GameNight.Shared.EntityClasses.Player", "Location")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("GameNight.Shared.EntityClasses.Logg", b =>
                {
                    b.HasOne("GameNight.Shared.EntityClasses.Player", "Dictator")
                        .WithMany()
                        .HasForeignKey("DictatorId");

                    b.Navigation("Dictator");
                });

            modelBuilder.Entity("GameNight.Shared.EntityClasses.Rating", b =>
                {
                    b.HasOne("GameNight.Shared.EntityClasses.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.HasOne("GameNight.Shared.EntityClasses.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("GameNight.Shared.EntityClasses.Subject", b =>
                {
                    b.HasOne("GameNight.Shared.EntityClasses.Logg", "Logg")
                        .WithMany("Subjects")
                        .HasForeignKey("LoggId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Logg");
                });

            modelBuilder.Entity("GameNight.Shared.EntityClasses.Logg", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
