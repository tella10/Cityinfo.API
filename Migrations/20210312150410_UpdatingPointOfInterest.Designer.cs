﻿// <auto-generated />
using Cityinfo.API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cityinfo.API.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    [Migration("20210312150410_UpdatingPointOfInterest")]
    partial class UpdatingPointOfInterest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cityinfo.API.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointOfInterest");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Description = "The famous place in Abuja",
                            Name = "Gwangalada"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Description = "The industrious city in Nigeria",
                            Name = "Lagos"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 2,
                            Description = "Everton Stadium in London UK",
                            Name = "Godison Park"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 3,
                            Description = "The famous city in US for best technology innovation",
                            Name = "Silicon Valley"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 3,
                            Description = "The famous city in US for best technology innovation",
                            Name = "Silicon Valley-1"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 4,
                            Description = "The famous city in US for best technology innovation",
                            Name = "Silicon Valley-1"
                        });
                });

            modelBuilder.Entity("Cityinfo.API.Entities.city", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "Nigeria",
                            Description = "The capital of Nigeria",
                            Name = "Abuja"
                        },
                        new
                        {
                            Id = 2,
                            Country = "Ghana",
                            Description = "The capital of Ghana",
                            Name = "Accra"
                        },
                        new
                        {
                            Id = 3,
                            Country = "United Kingdom",
                            Description = "The capital of United Kingdom",
                            Name = "London"
                        },
                        new
                        {
                            Id = 4,
                            Country = "United State",
                            Description = "The famous state in United State",
                            Name = "New York"
                        });
                });

            modelBuilder.Entity("Cityinfo.API.Entities.PointOfInterest", b =>
                {
                    b.HasOne("Cityinfo.API.Entities.city", "City")
                        .WithMany("PointOfInterest")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Cityinfo.API.Entities.city", b =>
                {
                    b.Navigation("PointOfInterest");
                });
#pragma warning restore 612, 618
        }
    }
}
