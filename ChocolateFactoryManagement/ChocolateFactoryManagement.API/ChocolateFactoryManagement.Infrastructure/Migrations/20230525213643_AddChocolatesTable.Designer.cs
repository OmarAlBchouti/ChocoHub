﻿// <auto-generated />
using ChocolateFactoryManagement.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChocolateFactoryManagement.Infrastructure.Migrations
{
    [DbContext(typeof(ChocolateFactoryDbContext))]
    [Migration("20230525213643_AddChocolatesTable")]
    partial class AddChocolatesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChocolateFactoryManagement.Domain.Models.ChocolateBar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FactoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.ToTable("ChocolateBars");
                });

            modelBuilder.Entity("ChocolateFactoryManagement.Domain.Models.Factory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Factories");
                });

            modelBuilder.Entity("ChocolateFactoryManagement.Domain.Models.Wholesaler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wholesalers");
                });

            modelBuilder.Entity("ChocolateFactoryManagement.Domain.Models.WholesalerStock", b =>
                {
                    b.Property<int>("WholesalerId")
                        .HasColumnType("int");

                    b.Property<int>("ChocolateBarId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("WholesalerId", "ChocolateBarId");

                    b.HasIndex("ChocolateBarId");

                    b.ToTable("WholesalerStocks");
                });

            modelBuilder.Entity("ChocolateFactoryManagement.Domain.Models.ChocolateBar", b =>
                {
                    b.HasOne("ChocolateFactoryManagement.Domain.Models.Factory", "Factory")
                        .WithMany("ChocolateBars")
                        .HasForeignKey("FactoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factory");
                });

            modelBuilder.Entity("ChocolateFactoryManagement.Domain.Models.WholesalerStock", b =>
                {
                    b.HasOne("ChocolateFactoryManagement.Domain.Models.ChocolateBar", "ChocolateBar")
                        .WithMany("WholesalerStocks")
                        .HasForeignKey("ChocolateBarId")
                        .IsRequired();

                    b.HasOne("ChocolateFactoryManagement.Domain.Models.Wholesaler", "Wholesaler")
                        .WithMany("WholesalerStocks")
                        .HasForeignKey("WholesalerId")
                        .IsRequired();

                    b.Navigation("ChocolateBar");

                    b.Navigation("Wholesaler");
                });

            modelBuilder.Entity("ChocolateFactoryManagement.Domain.Models.ChocolateBar", b =>
                {
                    b.Navigation("WholesalerStocks");
                });

            modelBuilder.Entity("ChocolateFactoryManagement.Domain.Models.Factory", b =>
                {
                    b.Navigation("ChocolateBars");
                });

            modelBuilder.Entity("ChocolateFactoryManagement.Domain.Models.Wholesaler", b =>
                {
                    b.Navigation("WholesalerStocks");
                });
#pragma warning restore 612, 618
        }
    }
}
