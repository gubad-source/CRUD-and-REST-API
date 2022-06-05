﻿// <auto-generated />
using ApiPractice.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiPractice.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220430100619_BlogTable")]
    partial class BlogTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiPractice.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Welcome to Jurrasic Park bitches",
                            Title = "T-rex"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Welcome to Jurrasic Park bitches",
                            Title = "Spinosaurus "
                        },
                        new
                        {
                            Id = 3,
                            Content = "Welcome to Jurrasic Park bitches",
                            Title = "Giganotosaurus"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}