﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api.Data;

#nullable disable

namespace PetParadiseApi.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231115173038_firstmigration")]
    partial class firstmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductID"));

                    b.Property<string>("AnimalCategory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BrandID")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Discount")
                        .HasColumnType("integer");

                    b.Property<int>("HasTax")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProviderID")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
