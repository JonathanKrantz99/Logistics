﻿// <auto-generated />
using System;
using Logistics.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Logistics.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230922115310_update")]
    partial class update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Logistics.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3eeabad7-ae68-45d2-bfc3-beba17ce9efa"),
                            Name = "Keyboard",
                            Removed = false
                        },
                        new
                        {
                            Id = new Guid("0a616438-9c96-44e3-b5fe-e318e0383c79"),
                            Name = "Headset",
                            Removed = false
                        },
                        new
                        {
                            Id = new Guid("af02a16a-87a3-49e3-a6da-f16e44c5cce3"),
                            Name = "Monitor",
                            Removed = false
                        });
                });

            modelBuilder.Entity("Logistics.Domain.Products.ProductSupplier", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ProductSupplier");

                    b.HasData(
                        new
                        {
                            Id = new Guid("56c8b90a-64f7-4483-99db-8f00f22a5f3d"),
                            ProductId = new Guid("3eeabad7-ae68-45d2-bfc3-beba17ce9efa"),
                            SupplierId = new Guid("9dae6a9e-f112-406c-bf2e-31874a24baa3")
                        },
                        new
                        {
                            Id = new Guid("9a72106e-0a6e-4b4e-92bd-061425299dca"),
                            ProductId = new Guid("0a616438-9c96-44e3-b5fe-e318e0383c79"),
                            SupplierId = new Guid("9dae6a9e-f112-406c-bf2e-31874a24baa3")
                        },
                        new
                        {
                            Id = new Guid("3a0dc838-8a43-4c52-ab71-082583eeee0e"),
                            ProductId = new Guid("af02a16a-87a3-49e3-a6da-f16e44c5cce3"),
                            SupplierId = new Guid("4c9a025b-1581-46dc-a982-f347b2cff27d")
                        });
                });

            modelBuilder.Entity("Logistics.Domain.Suppliers.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Supplier");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9dae6a9e-f112-406c-bf2e-31874a24baa3"),
                            Name = "Supplier 1",
                            Removed = false
                        },
                        new
                        {
                            Id = new Guid("4c9a025b-1581-46dc-a982-f347b2cff27d"),
                            Name = "Supplier 2",
                            Removed = false
                        });
                });

            modelBuilder.Entity("Logistics.Domain.Warehouses.History", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("SourceWarehouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TargetWarehouseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SourceWarehouseId");

                    b.HasIndex("TargetWarehouseId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("Logistics.Domain.Warehouses.StockItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("StockItem");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cff55678-1d84-4852-928e-ba5104196173"),
                            ProductId = new Guid("3eeabad7-ae68-45d2-bfc3-beba17ce9efa"),
                            Quantity = 40,
                            SupplierId = new Guid("9dae6a9e-f112-406c-bf2e-31874a24baa3"),
                            WarehouseId = new Guid("bf9288d0-48ef-43ae-b86a-f516d5583937")
                        },
                        new
                        {
                            Id = new Guid("9c36786a-e924-4dbd-97b1-3b9a1bfb6458"),
                            ProductId = new Guid("0a616438-9c96-44e3-b5fe-e318e0383c79"),
                            Quantity = 50,
                            SupplierId = new Guid("9dae6a9e-f112-406c-bf2e-31874a24baa3"),
                            WarehouseId = new Guid("bf9288d0-48ef-43ae-b86a-f516d5583937")
                        },
                        new
                        {
                            Id = new Guid("aab30ddb-4da9-440d-a7fb-817194a28e2c"),
                            ProductId = new Guid("af02a16a-87a3-49e3-a6da-f16e44c5cce3"),
                            Quantity = 200,
                            SupplierId = new Guid("4c9a025b-1581-46dc-a982-f347b2cff27d"),
                            WarehouseId = new Guid("21590c7c-2483-4d3a-9cd9-3505c2aa988e")
                        });
                });

            modelBuilder.Entity("Logistics.Domain.Warehouses.Warehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Warehouse");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bf9288d0-48ef-43ae-b86a-f516d5583937"),
                            Name = "Warehouse 1",
                            Removed = false
                        },
                        new
                        {
                            Id = new Guid("21590c7c-2483-4d3a-9cd9-3505c2aa988e"),
                            Name = "Warehouse 2",
                            Removed = false
                        });
                });

            modelBuilder.Entity("Logistics.Domain.Products.ProductSupplier", b =>
                {
                    b.HasOne("Logistics.Domain.Products.Product", null)
                        .WithMany("ProductSuppliers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Logistics.Domain.Suppliers.Supplier", null)
                        .WithMany("ProductSuppliers")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Logistics.Domain.Warehouses.History", b =>
                {
                    b.HasOne("Logistics.Domain.Warehouses.Warehouse", null)
                        .WithMany("HistoryMoved")
                        .HasForeignKey("SourceWarehouseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Logistics.Domain.Warehouses.Warehouse", null)
                        .WithMany("HistoryRecieved")
                        .HasForeignKey("TargetWarehouseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Logistics.Domain.Warehouses.StockItem", b =>
                {
                    b.HasOne("Logistics.Domain.Products.Product", null)
                        .WithMany("StockItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Logistics.Domain.Warehouses.Warehouse", null)
                        .WithMany("StockItems")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Logistics.Domain.Warehouses.Warehouse", b =>
                {
                    b.OwnsOne("Logistics.Domain.Warehouses.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("WarehouseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StreetNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("WarehouseId");

                            b1.ToTable("Warehouse");

                            b1.WithOwner()
                                .HasForeignKey("WarehouseId");

                            b1.HasData(
                                new
                                {
                                    WarehouseId = new Guid("bf9288d0-48ef-43ae-b86a-f516d5583937"),
                                    City = "Varberg",
                                    PostalCode = "43237",
                                    Street = "Träslövsvägen",
                                    StreetNumber = "171G"
                                },
                                new
                                {
                                    WarehouseId = new Guid("21590c7c-2483-4d3a-9cd9-3505c2aa988e"),
                                    City = "Varberg",
                                    PostalCode = "43236",
                                    Street = "Föreningsgatan",
                                    StreetNumber = "56"
                                });
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("Logistics.Domain.Products.Product", b =>
                {
                    b.Navigation("ProductSuppliers");

                    b.Navigation("StockItems");
                });

            modelBuilder.Entity("Logistics.Domain.Suppliers.Supplier", b =>
                {
                    b.Navigation("ProductSuppliers");
                });

            modelBuilder.Entity("Logistics.Domain.Warehouses.Warehouse", b =>
                {
                    b.Navigation("HistoryMoved");

                    b.Navigation("HistoryRecieved");

                    b.Navigation("StockItems");
                });
#pragma warning restore 612, 618
        }
    }
}