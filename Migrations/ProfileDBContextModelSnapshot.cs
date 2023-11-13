﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalSectorManager.Models;

#nullable disable

namespace PersonalSectorManager.Migrations
{
    [DbContext(typeof(ProfileDBContext))]
    partial class ProfileDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersonalSectorManager.Models.Sector", b =>
                {
                    b.Property<int>("SectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderIndex")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("SectorId");

                    b.HasIndex("ParentId");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("PersonalSectorManager.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<bool>("AgreeToTerms")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PersonalSectorManager.Models.UserSector", b =>
                {
                    b.Property<int>("UserSectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserSectorId"));

                    b.Property<int>("SectorId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserSectorId");

                    b.HasIndex("SectorId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSectors");
                });

            modelBuilder.Entity("PersonalSectorManager.Models.Sector", b =>
                {
                    b.HasOne("PersonalSectorManager.Models.Sector", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("PersonalSectorManager.Models.UserSector", b =>
                {
                    b.HasOne("PersonalSectorManager.Models.Sector", "Sector")
                        .WithMany("UserSectors")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalSectorManager.Models.User", "User")
                        .WithMany("UserSectors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sector");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PersonalSectorManager.Models.Sector", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("UserSectors");
                });

            modelBuilder.Entity("PersonalSectorManager.Models.User", b =>
                {
                    b.Navigation("UserSectors");
                });
#pragma warning restore 612, 618
        }
    }
}