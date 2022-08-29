﻿// <auto-generated />
using System;
using F1FantasyAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace F1FantasyAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220829084519_AddNewTabl")]
    partial class AddNewTabl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConstructorModelTeamModel", b =>
                {
                    b.Property<int>("ConstructorsId")
                        .HasColumnType("int");

                    b.Property<int>("TeamsId")
                        .HasColumnType("int");

                    b.HasKey("ConstructorsId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("ConstructorModelTeamModel");
                });

            modelBuilder.Entity("F1FantasyLibrary.ConstructorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Points")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Constructors");
                });

            modelBuilder.Entity("F1FantasyLibrary.FileModels.ConstructorFileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConstructorId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StorageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConstructorId")
                        .IsUnique();

                    b.ToTable("ConstructorLogos");
                });

            modelBuilder.Entity("F1FantasyLibrary.FileModels.GrandPrixFileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GrandPrixId")
                        .HasColumnType("int");

                    b.Property<string>("StorageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrandPrixId")
                        .IsUnique();

                    b.ToTable("GrandPrixFlags");
                });

            modelBuilder.Entity("F1FantasyLibrary.FileModels.RacerFileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RacerId")
                        .HasColumnType("int");

                    b.Property<string>("StorageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RacerId")
                        .IsUnique();

                    b.ToTable("RacerImages");
                });

            modelBuilder.Entity("F1FantasyLibrary.GrandPrixModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RacerModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RacerModelId");

                    b.ToTable("GrandPrix");
                });

            modelBuilder.Entity("F1FantasyLibrary.GrandPrixResultsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GrandPrixId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("RacerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrandPrixId");

                    b.HasIndex("RacerId");

                    b.ToTable("GrandPrixResults");
                });

            modelBuilder.Entity("F1FantasyLibrary.RacerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConstructorId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Points")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ConstructorId");

                    b.ToTable("Racers");
                });

            modelBuilder.Entity("F1FantasyLibrary.TeamModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("CashAvailable")
                        .HasColumnType("float");

                    b.Property<double>("CurrentCost")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Points")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("RacerModelTeamModel", b =>
                {
                    b.Property<int>("RacersId")
                        .HasColumnType("int");

                    b.Property<int>("TeamsId")
                        .HasColumnType("int");

                    b.HasKey("RacersId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("RacerModelTeamModel");
                });

            modelBuilder.Entity("ConstructorModelTeamModel", b =>
                {
                    b.HasOne("F1FantasyLibrary.ConstructorModel", null)
                        .WithMany()
                        .HasForeignKey("ConstructorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("F1FantasyLibrary.TeamModel", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("F1FantasyLibrary.FileModels.ConstructorFileModel", b =>
                {
                    b.HasOne("F1FantasyLibrary.ConstructorModel", "Constructor")
                        .WithOne("Logo")
                        .HasForeignKey("F1FantasyLibrary.FileModels.ConstructorFileModel", "ConstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Constructor");
                });

            modelBuilder.Entity("F1FantasyLibrary.FileModels.GrandPrixFileModel", b =>
                {
                    b.HasOne("F1FantasyLibrary.GrandPrixModel", "GrandPrix")
                        .WithOne("CountryFlag")
                        .HasForeignKey("F1FantasyLibrary.FileModels.GrandPrixFileModel", "GrandPrixId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrandPrix");
                });

            modelBuilder.Entity("F1FantasyLibrary.FileModels.RacerFileModel", b =>
                {
                    b.HasOne("F1FantasyLibrary.RacerModel", "Racer")
                        .WithOne("Image")
                        .HasForeignKey("F1FantasyLibrary.FileModels.RacerFileModel", "RacerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Racer");
                });

            modelBuilder.Entity("F1FantasyLibrary.GrandPrixModel", b =>
                {
                    b.HasOne("F1FantasyLibrary.RacerModel", null)
                        .WithMany("GrandPrix")
                        .HasForeignKey("RacerModelId");
                });

            modelBuilder.Entity("F1FantasyLibrary.GrandPrixResultsModel", b =>
                {
                    b.HasOne("F1FantasyLibrary.GrandPrixModel", "GrandPrix")
                        .WithMany("Results")
                        .HasForeignKey("GrandPrixId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("F1FantasyLibrary.RacerModel", "Racer")
                        .WithMany()
                        .HasForeignKey("RacerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrandPrix");

                    b.Navigation("Racer");
                });

            modelBuilder.Entity("F1FantasyLibrary.RacerModel", b =>
                {
                    b.HasOne("F1FantasyLibrary.ConstructorModel", "Constructor")
                        .WithMany("Racers")
                        .HasForeignKey("ConstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Constructor");
                });

            modelBuilder.Entity("RacerModelTeamModel", b =>
                {
                    b.HasOne("F1FantasyLibrary.RacerModel", null)
                        .WithMany()
                        .HasForeignKey("RacersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("F1FantasyLibrary.TeamModel", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("F1FantasyLibrary.ConstructorModel", b =>
                {
                    b.Navigation("Logo")
                        .IsRequired();

                    b.Navigation("Racers");
                });

            modelBuilder.Entity("F1FantasyLibrary.GrandPrixModel", b =>
                {
                    b.Navigation("CountryFlag")
                        .IsRequired();

                    b.Navigation("Results");
                });

            modelBuilder.Entity("F1FantasyLibrary.RacerModel", b =>
                {
                    b.Navigation("GrandPrix");

                    b.Navigation("Image")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
