﻿// <auto-generated />
using System;
using CafeteriaWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CafeteriaWebApi.Migrations
{
    [DbContext(typeof(CafeteriaContext))]
    partial class CafeteriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("CafeteriaWebApi.Data.Entities.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AdminId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DeliveryTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameOrder")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("IdOrder");

                    b.HasIndex("AdminId");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            IdOrder = 1,
                            ClientId = 2,
                            DeliveryTime = new DateTime(2023, 11, 23, 19, 17, 18, 886, DateTimeKind.Local).AddTicks(7670),
                            NameOrder = "Cafe",
                            Quantity = 0,
                            State = 1,
                            TotalPrice = 1050m
                        });
                });

            modelBuilder.Entity("CafeteriaWebApi.Data.Entities.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NameProduct")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("IdProduct");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            IdProduct = 1,
                            NameProduct = "Cafe",
                            Price = 1m
                        });
                });

            modelBuilder.Entity("CafeteriaWebApi.Data.Entities.SaleOrderLine", b =>
                {
                    b.Property<int>("IdSaleOrderLine")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Discount")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantityOfProduct")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdSaleOrderLine");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("SaleOrderLines");
                });

            modelBuilder.Entity("CafeteriaWebApi.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserState")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ProductSaleOrderLine", b =>
                {
                    b.Property<int>("ProductIdProduct")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SaleOrderLinesIdSaleOrderLine")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductIdProduct", "SaleOrderLinesIdSaleOrderLine");

                    b.HasIndex("SaleOrderLinesIdSaleOrderLine");

                    b.ToTable("ProductSaleOrderLine");
                });

            modelBuilder.Entity("CafeteriaWebApi.Data.Entities.Admin", b =>
                {
                    b.HasBaseType("CafeteriaWebApi.Data.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            Name = "admin",
                            Password = "admin",
                            UserState = 1
                        });
                });

            modelBuilder.Entity("CafeteriaWebApi.Data.Entities.Client", b =>
                {
                    b.HasBaseType("CafeteriaWebApi.Data.Entities.User");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Email = "client@gmail.com",
                            Name = "client",
                            Password = "client",
                            UserState = 1
                        });
                });

            modelBuilder.Entity("CafeteriaWebApi.Data.Entities.Order", b =>
                {
                    b.HasOne("CafeteriaWebApi.Data.Entities.Admin", null)
                        .WithMany("Orders")
                        .HasForeignKey("AdminId");

                    b.HasOne("CafeteriaWebApi.Data.Entities.Client", "Clients")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("CafeteriaWebApi.Data.Entities.SaleOrderLine", b =>
                {
                    b.HasOne("CafeteriaWebApi.Data.Entities.Order", "Orders")
                        .WithMany("SaleOrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CafeteriaWebApi.Data.Entities.Product", "Products")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ProductSaleOrderLine", b =>
                {
                    b.HasOne("CafeteriaWebApi.Data.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductIdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CafeteriaWebApi.Data.Entities.SaleOrderLine", null)
                        .WithMany()
                        .HasForeignKey("SaleOrderLinesIdSaleOrderLine")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CafeteriaWebApi.Data.Entities.Order", b =>
                {
                    b.Navigation("SaleOrderLines");
                });

            modelBuilder.Entity("CafeteriaWebApi.Data.Entities.Admin", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CafeteriaWebApi.Data.Entities.Client", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
