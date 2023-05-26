﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VacationHireInc.DataAccess;

#nullable disable

namespace VacationHireInc.DataAccess.Migrations
{
    [DbContext(typeof(VacationHireIncContext))]
    [Migration("20230526072537_AddRentableProduct")]
    partial class AddRentableProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VacationHireInc.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PaidAmount")
                        .HasColumnType("money");

                    b.Property<string>("PaidInCurrency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RentedProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReservedFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReservedUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RentedProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("VacationHireInc.Domain.Entities.RentableProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RentableProducts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("19847126-445e-48f7-97c7-1d25d71365d5"),
                            Name = "Truck"
                        },
                        new
                        {
                            Id = new Guid("74641849-26ec-4a1c-be8c-d7b4d6ffd83c"),
                            Name = "Minivan"
                        },
                        new
                        {
                            Id = new Guid("448edcd9-e7a0-47b3-975f-2e49ddb00040"),
                            Name = "Sedan"
                        });
                });

            modelBuilder.Entity("VacationHireInc.Domain.Entities.Order", b =>
                {
                    b.HasOne("VacationHireInc.Domain.Entities.RentableProduct", "RentedProduct")
                        .WithMany("Orders")
                        .HasForeignKey("RentedProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RentedProduct");
                });

            modelBuilder.Entity("VacationHireInc.Domain.Entities.RentableProduct", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
