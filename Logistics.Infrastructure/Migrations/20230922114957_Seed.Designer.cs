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
    [Migration("20230922114957_Seed")]
    partial class Seed
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
                            Id = new Guid("6fce5b91-659b-47fd-af97-9c5225ed3b46"),
                            Name = "Keyboard",
                            Removed = false
                        },
                        new
                        {
                            Id = new Guid("66e2f931-da68-4c09-a585-2792d51e887e"),
                            Name = "Headset",
                            Removed = false
                        },
                        new
                        {
                            Id = new Guid("4e9f971b-9879-4ed2-9f8e-1af456a43009"),
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
                            Id = new Guid("a78dd8b0-23e6-481f-9b55-57633838b094"),
                            ProductId = new Guid("6fce5b91-659b-47fd-af97-9c5225ed3b46"),
                            SupplierId = new Guid("4998a0d0-a2a9-4b13-b259-e5b29204a96a")
                        },
                        new
                        {
                            Id = new Guid("e6fa28ed-65cc-423d-a689-5f968e7468c5"),
                            ProductId = new Guid("66e2f931-da68-4c09-a585-2792d51e887e"),
                            SupplierId = new Guid("4998a0d0-a2a9-4b13-b259-e5b29204a96a")
                        },
                        new
                        {
                            Id = new Guid("6c43d9a5-ff99-40fb-ae8d-453f3d8a26a5"),
                            ProductId = new Guid("4e9f971b-9879-4ed2-9f8e-1af456a43009"),
                            SupplierId = new Guid("24ac99ee-2f39-4ee8-a18a-3e48e1afb36a")
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
                            Id = new Guid("4998a0d0-a2a9-4b13-b259-e5b29204a96a"),
                            Name = "Supplier 1",
                            Removed = false
                        },
                        new
                        {
                            Id = new Guid("24ac99ee-2f39-4ee8-a18a-3e48e1afb36a"),
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
                            Id = new Guid("81cb7e5c-3bf6-4e74-b60a-130fb37c4767"),
                            ProductId = new Guid("6fce5b91-659b-47fd-af97-9c5225ed3b46"),
                            Quantity = 40,
                            SupplierId = new Guid("4998a0d0-a2a9-4b13-b259-e5b29204a96a"),
                            WarehouseId = new Guid("ed457b5d-5c74-45d0-b42f-2fb8dd3a5b95")
                        },
                        new
                        {
                            Id = new Guid("8929b33c-18d1-4b4e-b158-ca2a25ce7229"),
                            ProductId = new Guid("66e2f931-da68-4c09-a585-2792d51e887e"),
                            Quantity = 50,
                            SupplierId = new Guid("4998a0d0-a2a9-4b13-b259-e5b29204a96a"),
                            WarehouseId = new Guid("ed457b5d-5c74-45d0-b42f-2fb8dd3a5b95")
                        },
                        new
                        {
                            Id = new Guid("42e578b5-3d92-44d2-a97a-d34a04b6120f"),
                            ProductId = new Guid("4e9f971b-9879-4ed2-9f8e-1af456a43009"),
                            Quantity = 200,
                            SupplierId = new Guid("24ac99ee-2f39-4ee8-a18a-3e48e1afb36a"),
                            WarehouseId = new Guid("f9168bfb-e93e-47ba-8b9e-8f77cb469a6f")
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
                            Id = new Guid("ed457b5d-5c74-45d0-b42f-2fb8dd3a5b95"),
                            Name = "Warehouse 1",
                            Removed = false
                        },
                        new
                        {
                            Id = new Guid("f9168bfb-e93e-47ba-8b9e-8f77cb469a6f"),
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
                                    WarehouseId = new Guid("ed457b5d-5c74-45d0-b42f-2fb8dd3a5b95"),
                                    City = "Varberg",
                                    PostalCode = "43237",
                                    Street = "Träslövsvägen",
                                    StreetNumber = "171G"
                                },
                                new
                                {
                                    WarehouseId = new Guid("f9168bfb-e93e-47ba-8b9e-8f77cb469a6f"),
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