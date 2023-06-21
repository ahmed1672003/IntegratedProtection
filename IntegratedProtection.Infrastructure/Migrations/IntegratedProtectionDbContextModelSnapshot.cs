﻿// <auto-generated />
using System;
using IntegratedProtection.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IntegratedProtection.Infrastructure.Migrations
{
    [DbContext(typeof(IntegratedProtectionDbContext))]
    partial class IntegratedProtectionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IntegratedProtection.Core.CentralSecurity.Criminal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedData")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("Id");

                    b.ToTable("Criminals", "CentralSecurity");
                });

            modelBuilder.Entity("IntegratedProtection.Core.CivilRegistry.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Cards", "CivilRegistry");
                });

            modelBuilder.Entity("IntegratedProtection.Core.CivilRegistry.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Center")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Governorate")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MiddelName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Religion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Persons", "CivilRegistry");
                });

            modelBuilder.Entity("IntegratedProtection.Core.Traffic.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Letters")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OwnerSSN")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("Id");

                    b.ToTable("Cars", "Traffic");
                });

            modelBuilder.Entity("IntegratedProtection.Core.Traffic.CarDriver", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedData")
                        .HasColumnType("datetime2");

                    b.HasKey("CarId", "DriverId");

                    b.HasIndex("DriverId");

                    b.ToTable("CarsDrivers", "Traffic");
                });

            modelBuilder.Entity("IntegratedProtection.Core.Traffic.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("Id");

                    b.ToTable("Drivers", "Traffic");
                });

            modelBuilder.Entity("IntegratedProtection.Core.Traffic.StolenCar", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("TrafficOfficerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CarId", "TrafficOfficerId");

                    b.HasIndex("TrafficOfficerId");

                    b.ToTable("StolenCars", "Traffic");
                });

            modelBuilder.Entity("IntegratedProtection.Core.Traffic.TrafficOfficer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Center")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MiddelName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TrafficOfficers", "Traffic");
                });

            modelBuilder.Entity("IntegratedProtection.Core.CivilRegistry.Card", b =>
                {
                    b.HasOne("IntegratedProtection.Core.CivilRegistry.Person", "Person")
                        .WithOne("Card")
                        .HasForeignKey("IntegratedProtection.Core.CivilRegistry.Card", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("IntegratedProtection.Core.Traffic.CarDriver", b =>
                {
                    b.HasOne("IntegratedProtection.Core.Traffic.Car", "Car")
                        .WithMany("CarDriver")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntegratedProtection.Core.Traffic.Driver", "Driver")
                        .WithMany("CarsDrivers")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("IntegratedProtection.Core.Traffic.StolenCar", b =>
                {
                    b.HasOne("IntegratedProtection.Core.Traffic.Car", "Car")
                        .WithMany("StolenCars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntegratedProtection.Core.Traffic.TrafficOfficer", "TrafficOfficer")
                        .WithMany("StolenCars")
                        .HasForeignKey("TrafficOfficerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("TrafficOfficer");
                });

            modelBuilder.Entity("IntegratedProtection.Core.CivilRegistry.Person", b =>
                {
                    b.Navigation("Card")
                        .IsRequired();
                });

            modelBuilder.Entity("IntegratedProtection.Core.Traffic.Car", b =>
                {
                    b.Navigation("CarDriver");

                    b.Navigation("StolenCars");
                });

            modelBuilder.Entity("IntegratedProtection.Core.Traffic.Driver", b =>
                {
                    b.Navigation("CarsDrivers");
                });

            modelBuilder.Entity("IntegratedProtection.Core.Traffic.TrafficOfficer", b =>
                {
                    b.Navigation("StolenCars");
                });
#pragma warning restore 612, 618
        }
    }
}
