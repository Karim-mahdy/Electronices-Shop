﻿// <auto-generated />
using System;
using DMSTask.Infrastrcture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DMSTask.Infrastrcture.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DMSTask.Domain.Entities.Device", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("AcquisitionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeviceCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("DeviceName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Memo")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("ID");

                    b.HasIndex("DeviceCategoryID");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("DMSTask.Domain.Entities.DeviceCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ID");

                    b.ToTable("DeviceCategories");
                });

            modelBuilder.Entity("DMSTask.Domain.Entities.PropertyItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DeviceCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("PropertyDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ID");

                    b.HasIndex("DeviceCategoryID");

                    b.ToTable("PropertyItems");
                });

            modelBuilder.Entity("DMSTask.Domain.Entities.PropertyValue", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DeviceID")
                        .HasColumnType("int");

                    b.Property<int>("PropertyItemID")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ID");

                    b.HasIndex("DeviceID");

                    b.HasIndex("PropertyItemID");

                    b.ToTable("PropertyValues");
                });

            modelBuilder.Entity("DMSTask.Domain.Entities.Device", b =>
                {
                    b.HasOne("DMSTask.Domain.Entities.DeviceCategory", "DeviceCategory")
                        .WithMany("Devices")
                        .HasForeignKey("DeviceCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceCategory");
                });

            modelBuilder.Entity("DMSTask.Domain.Entities.PropertyItem", b =>
                {
                    b.HasOne("DMSTask.Domain.Entities.DeviceCategory", "DeviceCategory")
                        .WithMany("PropertyItems")
                        .HasForeignKey("DeviceCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceCategory");
                });

            modelBuilder.Entity("DMSTask.Domain.Entities.PropertyValue", b =>
                {
                    b.HasOne("DMSTask.Domain.Entities.Device", "Device")
                        .WithMany("PropertyValues")
                        .HasForeignKey("DeviceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DMSTask.Domain.Entities.PropertyItem", "PropertyItem")
                        .WithMany()
                        .HasForeignKey("PropertyItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("PropertyItem");
                });

            modelBuilder.Entity("DMSTask.Domain.Entities.Device", b =>
                {
                    b.Navigation("PropertyValues");
                });

            modelBuilder.Entity("DMSTask.Domain.Entities.DeviceCategory", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("PropertyItems");
                });
#pragma warning restore 612, 618
        }
    }
}
