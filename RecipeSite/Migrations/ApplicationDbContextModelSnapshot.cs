﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeSite.Models;

namespace RecipeSite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecipeSite.Models.AddRecipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CookingTimeInMin");

                    b.Property<int?>("CuisineID");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("DifficultyLevel")
                        .IsRequired();

                    b.Property<string>("IngredientList")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("RecipeID");

                    b.HasIndex("CuisineID");

                    b.ToTable("AddRecipes");
                });

            modelBuilder.Entity("RecipeSite.Models.Cuisine", b =>
                {
                    b.Property<int>("CuisineID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CuisineType")
                        .IsRequired();

                    b.HasKey("CuisineID");

                    b.ToTable("Cuisines");
                });

            modelBuilder.Entity("RecipeSite.Models.AddRecipe", b =>
                {
                    b.HasOne("RecipeSite.Models.Cuisine", "Cuisine")
                        .WithMany()
                        .HasForeignKey("CuisineID");
                });
#pragma warning restore 612, 618
        }
    }
}
