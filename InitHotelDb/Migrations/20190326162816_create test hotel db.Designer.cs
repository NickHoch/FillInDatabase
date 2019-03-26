﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSiteCore.DAL.Entities;

namespace InitHotelDb.Migrations
{
    [DbContext(typeof(EFDbContext))]
    [Migration("20190326162816_create test hotel db")]
    partial class createtesthoteldb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebSiteCore.DAL.Entities.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Area");

                    b.Property<int>("ConvenienceTypeId");

                    b.Property<string>("Description");

                    b.Property<string>("Equipment");

                    b.Property<int>("FloorId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<double>("Price");

                    b.Property<int>("RoomQuantity");

                    b.Property<int>("RoomTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ConvenienceTypeId");

                    b.HasIndex("FloorId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("tblApartments");
                });

            modelBuilder.Entity("WebSiteCore.DAL.Entities.ApartmentImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppartmentId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("AppartmentId");

                    b.ToTable("tblApartmentImages");
                });

            modelBuilder.Entity("WebSiteCore.DAL.Entities.BoardType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("tblBoardTypes");
                });

            modelBuilder.Entity("WebSiteCore.DAL.Entities.ConvenienceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("tblConvenienceTypes");
                });

            modelBuilder.Entity("WebSiteCore.DAL.Entities.Floor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("tblFloors");
                });

            modelBuilder.Entity("WebSiteCore.DAL.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime?>("From");

                    b.Property<string>("ImageName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime?>("To");

                    b.HasKey("Id");

                    b.ToTable("tblOffers");
                });

            modelBuilder.Entity("WebSiteCore.DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApartmentId");

                    b.Property<int>("BoardTypeId");

                    b.Property<string>("ClientId");

                    b.Property<DateTime?>("From");

                    b.Property<double>("Price");

                    b.Property<DateTime?>("To");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("BoardTypeId");

                    b.ToTable("tblOrders");
                });

            modelBuilder.Entity("WebSiteCore.DAL.Entities.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("tblRoomTypes");
                });

            modelBuilder.Entity("WebSiteCore.DAL.Entities.Apartment", b =>
                {
                    b.HasOne("WebSiteCore.DAL.Entities.ConvenienceType", "ConvenienceType")
                        .WithMany("Apartments")
                        .HasForeignKey("ConvenienceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebSiteCore.DAL.Entities.Floor", "Floor")
                        .WithMany("Apartments")
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebSiteCore.DAL.Entities.RoomType", "RoomType")
                        .WithMany("Apartments")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebSiteCore.DAL.Entities.ApartmentImage", b =>
                {
                    b.HasOne("WebSiteCore.DAL.Entities.Apartment", "Apartment")
                        .WithMany("Images")
                        .HasForeignKey("AppartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebSiteCore.DAL.Entities.Order", b =>
                {
                    b.HasOne("WebSiteCore.DAL.Entities.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebSiteCore.DAL.Entities.BoardType", "BoardType")
                        .WithMany("Orders")
                        .HasForeignKey("BoardTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
