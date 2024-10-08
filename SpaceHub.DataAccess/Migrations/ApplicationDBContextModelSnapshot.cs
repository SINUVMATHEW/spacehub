﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceHub.DataAccess.Data;

#nullable disable

namespace SpaceHub.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SpaceHub.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BookingDate")
                        .HasColumnType("date");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WorkspaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookingDate = new DateOnly(2024, 9, 2),
                            UserId = 1,
                            WorkspaceId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookingDate = new DateOnly(2024, 9, 2),
                            UserId = 2,
                            WorkspaceId = 2
                        });
                });

            modelBuilder.Entity("SpaceHub.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "sinu@gmail.com",
                            Name = "Sinu V Mathew"
                        },
                        new
                        {
                            Id = 2,
                            Email = "melinda@gmail.com",
                            Name = "Melinda Mary"
                        },
                        new
                        {
                            Id = 3,
                            Email = "kailas@gmail.com",
                            Name = "Kailas S"
                        });
                });

            modelBuilder.Entity("SpaceHub.Models.Workspace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<int>("Module")
                        .HasColumnType("int");

                    b.Property<int>("SeatNo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Workspaces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Building = "TVRM-Thejaswini",
                            Module = 1,
                            SeatNo = 1
                        },
                        new
                        {
                            Id = 2,
                            Building = "TVRM-Thejaswini",
                            Module = 1,
                            SeatNo = 2
                        },
                        new
                        {
                            Id = 3,
                            Building = "TVRM-Thejaswini",
                            Module = 1,
                            SeatNo = 3
                        });
                });

            modelBuilder.Entity("SpaceHub.Models.Booking", b =>
                {
                    b.HasOne("SpaceHub.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpaceHub.Models.Workspace", "Workspace")
                        .WithMany()
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Workspace");
                });
#pragma warning restore 612, 618
        }
    }
}
