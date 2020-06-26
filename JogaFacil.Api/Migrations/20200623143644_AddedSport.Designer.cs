﻿// <auto-generated />
using System;
using JogaFacil.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JogaFacil.Api.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200623143644_AddedSport")]
    partial class AddedSport
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JogaFacil.Api.Entities.Arena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Sport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Arenas");
                });

            modelBuilder.Entity("JogaFacil.Api.Entities.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("JogaFacil.Api.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArenaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArenaId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("JogaFacil.Api.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JogaFacil.Api.Entities.Arena", b =>
                {
                    b.HasOne("JogaFacil.Api.Entities.Place", null)
                        .WithMany("Arenas")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("JogaFacil.Api.Entities.Place", b =>
                {
                    b.HasOne("JogaFacil.Api.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.OwnsOne("JogaFacil.Api.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("PlaceId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Neighbourhood")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Number")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PlaceId");

                            b1.ToTable("Places");

                            b1.WithOwner()
                                .HasForeignKey("PlaceId");
                        });

                    b.OwnsOne("JogaFacil.Api.Entities.OpenHours", "OpenHours", b1 =>
                        {
                            b1.Property<int>("PlaceId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.HasKey("PlaceId");

                            b1.ToTable("Places");

                            b1.WithOwner()
                                .HasForeignKey("PlaceId");

                            b1.OwnsOne("JogaFacil.Api.Entities.OpenHoursDay", "Friday", b2 =>
                                {
                                    b2.Property<int>("OpenHoursPlaceId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<DateTime>("ClosingHour")
                                        .HasColumnType("datetime2");

                                    b2.Property<DateTime>("OpeningHour")
                                        .HasColumnType("datetime2");

                                    b2.HasKey("OpenHoursPlaceId");

                                    b2.ToTable("Places");

                                    b2.WithOwner()
                                        .HasForeignKey("OpenHoursPlaceId");
                                });

                            b1.OwnsOne("JogaFacil.Api.Entities.OpenHoursDay", "Monday", b2 =>
                                {
                                    b2.Property<int>("OpenHoursPlaceId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<DateTime>("ClosingHour")
                                        .HasColumnType("datetime2");

                                    b2.Property<DateTime>("OpeningHour")
                                        .HasColumnType("datetime2");

                                    b2.HasKey("OpenHoursPlaceId");

                                    b2.ToTable("Places");

                                    b2.WithOwner()
                                        .HasForeignKey("OpenHoursPlaceId");
                                });

                            b1.OwnsOne("JogaFacil.Api.Entities.OpenHoursDay", "Saturday", b2 =>
                                {
                                    b2.Property<int>("OpenHoursPlaceId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<DateTime>("ClosingHour")
                                        .HasColumnType("datetime2");

                                    b2.Property<DateTime>("OpeningHour")
                                        .HasColumnType("datetime2");

                                    b2.HasKey("OpenHoursPlaceId");

                                    b2.ToTable("Places");

                                    b2.WithOwner()
                                        .HasForeignKey("OpenHoursPlaceId");
                                });

                            b1.OwnsOne("JogaFacil.Api.Entities.OpenHoursDay", "Sunday", b2 =>
                                {
                                    b2.Property<int>("OpenHoursPlaceId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<DateTime>("ClosingHour")
                                        .HasColumnType("datetime2");

                                    b2.Property<DateTime>("OpeningHour")
                                        .HasColumnType("datetime2");

                                    b2.HasKey("OpenHoursPlaceId");

                                    b2.ToTable("Places");

                                    b2.WithOwner()
                                        .HasForeignKey("OpenHoursPlaceId");
                                });

                            b1.OwnsOne("JogaFacil.Api.Entities.OpenHoursDay", "Thursday", b2 =>
                                {
                                    b2.Property<int>("OpenHoursPlaceId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<DateTime>("ClosingHour")
                                        .HasColumnType("datetime2");

                                    b2.Property<DateTime>("OpeningHour")
                                        .HasColumnType("datetime2");

                                    b2.HasKey("OpenHoursPlaceId");

                                    b2.ToTable("Places");

                                    b2.WithOwner()
                                        .HasForeignKey("OpenHoursPlaceId");
                                });

                            b1.OwnsOne("JogaFacil.Api.Entities.OpenHoursDay", "Tuesday", b2 =>
                                {
                                    b2.Property<int>("OpenHoursPlaceId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<DateTime>("ClosingHour")
                                        .HasColumnType("datetime2");

                                    b2.Property<DateTime>("OpeningHour")
                                        .HasColumnType("datetime2");

                                    b2.HasKey("OpenHoursPlaceId");

                                    b2.ToTable("Places");

                                    b2.WithOwner()
                                        .HasForeignKey("OpenHoursPlaceId");
                                });

                            b1.OwnsOne("JogaFacil.Api.Entities.OpenHoursDay", "Wednesday", b2 =>
                                {
                                    b2.Property<int>("OpenHoursPlaceId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<DateTime>("ClosingHour")
                                        .HasColumnType("datetime2");

                                    b2.Property<DateTime>("OpeningHour")
                                        .HasColumnType("datetime2");

                                    b2.HasKey("OpenHoursPlaceId");

                                    b2.ToTable("Places");

                                    b2.WithOwner()
                                        .HasForeignKey("OpenHoursPlaceId");
                                });
                        });
                });

            modelBuilder.Entity("JogaFacil.Api.Entities.Reservation", b =>
                {
                    b.HasOne("JogaFacil.Api.Entities.Arena", "Arena")
                        .WithMany()
                        .HasForeignKey("ArenaId");

                    b.HasOne("JogaFacil.Api.Entities.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");

                    b.HasOne("JogaFacil.Api.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("JogaFacil.Api.Entities.User", b =>
                {
                    b.HasOne("JogaFacil.Api.Entities.Place", null)
                        .WithMany("Admins")
                        .HasForeignKey("PlaceId");
                });
#pragma warning restore 612, 618
        }
    }
}