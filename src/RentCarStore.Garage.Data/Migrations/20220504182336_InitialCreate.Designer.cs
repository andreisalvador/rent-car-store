﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RentCarStore.Garage.Data;

#nullable disable

namespace RentCarStore.Garage.Data.Migrations
{
    [DbContext(typeof(GarageContext))]
    [Migration("20220504182336_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RestCarStore.Garage.Domain.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Acessories")
                        .HasColumnType("integer");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<int>("Color")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("RestCarStore.Garage.Domain.CarRentalStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("PickedUpIn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("RentedBy")
                        .HasColumnType("uuid");

                    b.Property<DateOnly?>("ReturnsIn")
                        .HasColumnType("date");

                    b.HasKey("Id", "CarId");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("CarRentalStatus");
                });

            modelBuilder.Entity("RestCarStore.Garage.Domain.CarRentalStatus", b =>
                {
                    b.HasOne("RestCarStore.Garage.Domain.Car", "Car")
                        .WithOne("RentalStatus")
                        .HasForeignKey("RestCarStore.Garage.Domain.CarRentalStatus", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("RestCarStore.Garage.Domain.Car", b =>
                {
                    b.Navigation("RentalStatus")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
