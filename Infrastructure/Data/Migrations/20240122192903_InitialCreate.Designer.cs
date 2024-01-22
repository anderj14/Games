﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(GamesRoomContext))]
    [Migration("20240122192903_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Core.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Core.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryOrigin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("YearFounded")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Core.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Developer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GameConsoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GamePictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RelaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GameConsoleId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Core.Entities.GameConsole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConsoleName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("TechnicalSpecificationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("TechnicalSpecificationId");

                    b.ToTable("GameConsoles");
                });

            modelBuilder.Entity("Core.Entities.TechnicalSpecification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPU")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GPU")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxFPS")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MaxResolution")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RAM")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TechnicalSpecifications");
                });

            modelBuilder.Entity("Core.Entities.Game", b =>
                {
                    b.HasOne("Core.Entities.GameConsole", "GameConsole")
                        .WithMany()
                        .HasForeignKey("GameConsoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameConsole");
                });

            modelBuilder.Entity("Core.Entities.GameConsole", b =>
                {
                    b.HasOne("Core.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TechnicalSpecification", "TechnicalSpecification")
                        .WithMany()
                        .HasForeignKey("TechnicalSpecificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Company");

                    b.Navigation("TechnicalSpecification");
                });
#pragma warning restore 612, 618
        }
    }
}
