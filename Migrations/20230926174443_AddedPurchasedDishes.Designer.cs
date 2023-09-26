﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantManagement.Context;

#nullable disable

namespace RestaurantManagement.Migrations
{
    [DbContext(typeof(RestaurantManagementContext))]
    [Migration("20230926174443_AddedPurchasedDishes")]
    partial class AddedPurchasedDishes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantManagement.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Best Dish",
                            Price = 12.33
                        },
                        new
                        {
                            Id = 2,
                            Name = "Worst",
                            Price = 2.1200000000000001
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dutch Anger",
                            Price = 6.6600000000000001
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fishy Stuff",
                            Price = 12.33
                        },
                        new
                        {
                            Id = 5,
                            Name = "Moowie Woowie",
                            Price = 12.33
                        });
                });

            modelBuilder.Entity("RestaurantManagement.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("TimeOfPurchase")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("RestaurantManagement.Models.PurchasedDish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchasedDishes");
                });

            modelBuilder.Entity("RestaurantManagement.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = 1,
                            TotalPrice = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 2,
                            Number = 2,
                            TotalPrice = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 3,
                            Number = 3,
                            TotalPrice = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 4,
                            Number = 4,
                            TotalPrice = 0.0,
                            isAvailable = true
                        },
                        new
                        {
                            Id = 5,
                            Number = 5,
                            TotalPrice = 0.0,
                            isAvailable = true
                        });
                });

            modelBuilder.Entity("RestaurantManagement.Models.TableDish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.ToTable("TableDishes");
                });

            modelBuilder.Entity("RestaurantManagement.Models.PurchasedDish", b =>
                {
                    b.HasOne("RestaurantManagement.Models.Purchase", null)
                        .WithMany("PurchasedDishes")
                        .HasForeignKey("PurchaseId");
                });

            modelBuilder.Entity("RestaurantManagement.Models.TableDish", b =>
                {
                    b.HasOne("RestaurantManagement.Models.Table", null)
                        .WithMany("TableDishes")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantManagement.Models.Purchase", b =>
                {
                    b.Navigation("PurchasedDishes");
                });

            modelBuilder.Entity("RestaurantManagement.Models.Table", b =>
                {
                    b.Navigation("TableDishes");
                });
#pragma warning restore 612, 618
        }
    }
}