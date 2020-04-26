﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupportManagementCenter.Models;

namespace SupportManagementCenter.Migrations
{
    [DbContext(typeof(SupportManagementCenterDBContext))]
    [Migration("20200426172220_CorrispondenceAddMigration")]
    partial class CorrispondenceAddMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SupportManagementCenter.Models.EmployeesModel", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductExpertise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SupportTicketModelTicketId")
                        .HasColumnType("bigint");

                    b.HasKey("EmployeeId");

                    b.HasIndex("SupportTicketModelTicketId");

                    b.ToTable("EmployeesModel");
                });

            modelBuilder.Entity("SupportManagementCenter.Models.ProductsModel", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProduceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SupportTicketModelTicketId")
                        .HasColumnType("bigint");

                    b.HasKey("ProductId");

                    b.HasIndex("SupportTicketModelTicketId");

                    b.ToTable("ProductsModel");
                });

            modelBuilder.Entity("SupportManagementCenter.Models.SupportTicketModel", b =>
                {
                    b.Property<long>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRaised")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("TicketDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TicketTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketId");

                    b.ToTable("supportTickets");
                });

            modelBuilder.Entity("SupportManagementCenter.Models.EmployeesModel", b =>
                {
                    b.HasOne("SupportManagementCenter.Models.SupportTicketModel", null)
                        .WithMany("AssignedEmployee")
                        .HasForeignKey("SupportTicketModelTicketId");
                });

            modelBuilder.Entity("SupportManagementCenter.Models.ProductsModel", b =>
                {
                    b.HasOne("SupportManagementCenter.Models.SupportTicketModel", null)
                        .WithMany("ProductsId")
                        .HasForeignKey("SupportTicketModelTicketId");
                });
#pragma warning restore 612, 618
        }
    }
}