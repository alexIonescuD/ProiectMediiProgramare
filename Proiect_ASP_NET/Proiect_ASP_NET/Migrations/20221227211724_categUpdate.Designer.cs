﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_ASP_NET.Data;

#nullable disable

namespace Proiect_ASP_NET.Migrations
{
    [DbContext(typeof(Proiect_ASP_NETContext))]
    [Migration("20221227211724_categUpdate")]
    partial class categUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_ASP_NET.Models.Brand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("BrandID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EstablishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Proiect_ASP_NET.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("BrandID")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int?>("DealerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FabricationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("DealerID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Proiect_ASP_NET.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Proiect_ASP_NET.Models.Dealer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DealerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Dealer");
                });

            modelBuilder.Entity("Proiect_ASP_NET.Models.Brand", b =>
                {
                    b.HasOne("Proiect_ASP_NET.Models.Brand", null)
                        .WithMany("Brands")
                        .HasForeignKey("BrandID");
                });

            modelBuilder.Entity("Proiect_ASP_NET.Models.Car", b =>
                {
                    b.HasOne("Proiect_ASP_NET.Models.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandID");

                    b.HasOne("Proiect_ASP_NET.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("Proiect_ASP_NET.Models.Dealer", "Dealer")
                        .WithMany("Cars")
                        .HasForeignKey("DealerID");

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("Proiect_ASP_NET.Models.Brand", b =>
                {
                    b.Navigation("Brands");

                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Proiect_ASP_NET.Models.Dealer", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
