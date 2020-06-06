﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockPharma.Infrastructure;

namespace StockPharma.Infrastructure.Migrations
{
    [DbContext(typeof(StockPharmaContext))]
    [Migration("20200531075104_MigrationStockPharma")]
    partial class MigrationStockPharma
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockPharma.Core.Entities.Medicament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("medicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
