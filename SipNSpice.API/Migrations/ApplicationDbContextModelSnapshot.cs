﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SipNSpice.API.Data;

#nullable disable

namespace SipNSpice.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BaseDrink", b =>
                {
                    b.Property<Guid>("BasesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DrinksId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BasesId", "DrinksId");

                    b.HasIndex("DrinksId");

                    b.ToTable("BaseDrink");
                });

            modelBuilder.Entity("CuisineRecipe", b =>
                {
                    b.Property<Guid>("CuisinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CuisinesId", "RecipesId");

                    b.HasIndex("RecipesId");

                    b.ToTable("CuisineRecipe");
                });

            modelBuilder.Entity("SipNSpice.API.Models.Domain.Base", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bases");
                });

            modelBuilder.Entity("SipNSpice.API.Models.Domain.Cuisine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MainCuisine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCuisine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cuisines");
                });

            modelBuilder.Entity("SipNSpice.API.Models.Domain.Drink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("SipNSpice.API.Models.Domain.DrinkImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DrinkImages");
                });

            modelBuilder.Entity("SipNSpice.API.Models.Domain.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("SipNSpice.API.Models.Domain.RecipeImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecipeImages");
                });

            modelBuilder.Entity("BaseDrink", b =>
                {
                    b.HasOne("SipNSpice.API.Models.Domain.Base", null)
                        .WithMany()
                        .HasForeignKey("BasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SipNSpice.API.Models.Domain.Drink", null)
                        .WithMany()
                        .HasForeignKey("DrinksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CuisineRecipe", b =>
                {
                    b.HasOne("SipNSpice.API.Models.Domain.Cuisine", null)
                        .WithMany()
                        .HasForeignKey("CuisinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SipNSpice.API.Models.Domain.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
