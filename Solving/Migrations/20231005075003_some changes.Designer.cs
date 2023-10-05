﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solving.DbCon;

#nullable disable

namespace Solving.Migrations
{
    [DbContext(typeof(DemoProjectDbContext))]
    [Migration("20231005075003_some changes")]
    partial class somechanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Solving.Model.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeetbemployeeId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("attendanceDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<int>("isAbsent")
                        .HasColumnType("int");

                    b.Property<int>("isOffday")
                        .HasColumnType("int");

                    b.Property<int>("isPresent")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeetbemployeeId");

                    b.ToTable("attendances");
                });

            modelBuilder.Entity("Solving.Model.Employeetb", b =>
                {
                    b.Property<int>("employeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("employeeId"));

                    b.Property<string>("employeeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employeeSalary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("supervisorId")
                        .HasColumnType("int");

                    b.HasKey("employeeId");

                    b.ToTable("employeetbs");
                });

            modelBuilder.Entity("Solving.Model.Attendance", b =>
                {
                    b.HasOne("Solving.Model.Employeetb", null)
                        .WithMany("Attendances")
                        .HasForeignKey("EmployeetbemployeeId");
                });

            modelBuilder.Entity("Solving.Model.Employeetb", b =>
                {
                    b.Navigation("Attendances");
                });
#pragma warning restore 612, 618
        }
    }
}
