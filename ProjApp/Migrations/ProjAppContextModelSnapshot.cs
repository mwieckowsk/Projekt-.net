﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ProjApp.Data;
using System;

namespace ProjApp.Migrations
{
    [DbContext(typeof(ProjAppContext))]
    partial class ProjAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjApp.Models.Brand", b =>
                {
                    b.Property<string>("BrandId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("BrandId");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("ProjApp.Models.Car", b =>
                {
                    b.Property<string>("CarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrandId");

                    b.Property<decimal>("Built");

                    b.Property<string>("CountryId");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Type");

                    b.HasKey("CarId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CountryId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("ProjApp.Models.Country", b =>
                {
                    b.Property<string>("CountryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CountryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("ProjApp.Models.Car", b =>
                {
                    b.HasOne("ProjApp.Models.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId");

                    b.HasOne("ProjApp.Models.Country", "Country")
                        .WithMany("Cars")
                        .HasForeignKey("CountryId");
                });
#pragma warning restore 612, 618
        }
    }
}
