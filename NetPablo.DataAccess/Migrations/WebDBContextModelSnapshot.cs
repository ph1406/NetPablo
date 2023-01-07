﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetPablo.DataAccess;

#nullable disable

namespace NetPablo.DataAccess.Migrations
{
    [DbContext(typeof(WebDBContext))]
    partial class WebDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NetPablo.Domain.Cart", b =>
                {
                    b.Property<int>("lineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("lineId"));

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("idProduct")
                        .HasColumnType("int");

                    b.Property<string>("idUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("priceCalculated")
                        .HasPrecision(2)
                        .HasColumnType("float(2)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("lineId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("NetPablo.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlternativeName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(150)");

                    b.Property<double>("Price")
                        .HasPrecision(2)
                        .HasColumnType("float(2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlternativeName = "Telefono Alcatel",
                            CreationDate = new DateTime(2023, 1, 7, 0, 44, 14, 847, DateTimeKind.Local).AddTicks(9124),
                            Name = "Telefono celular",
                            Price = 50000.0,
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            AlternativeName = "Marca Naik",
                            CreationDate = new DateTime(2023, 1, 7, 0, 44, 14, 847, DateTimeKind.Local).AddTicks(9159),
                            Name = "Zapatilla",
                            Price = 25000.0,
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            AlternativeName = "Fruta organica",
                            CreationDate = new DateTime(2023, 1, 7, 0, 44, 14, 847, DateTimeKind.Local).AddTicks(9162),
                            Name = "Manzana",
                            Price = 150.0,
                            Status = true
                        },
                        new
                        {
                            Id = 4,
                            AlternativeName = "Chaleco de lana",
                            CreationDate = new DateTime(2023, 1, 7, 0, 44, 14, 847, DateTimeKind.Local).AddTicks(9164),
                            Name = "Chaleco",
                            Price = 35000.0,
                            Status = true
                        },
                        new
                        {
                            Id = 5,
                            AlternativeName = "Mouse con bluetooth",
                            CreationDate = new DateTime(2023, 1, 7, 0, 44, 14, 847, DateTimeKind.Local).AddTicks(9166),
                            Name = "Mouse Inalambrico",
                            Price = 15000.0,
                            Status = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
