﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMovieApp.Data.DataConnection;

namespace MyMovieApp.Data.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20220531090630_movieapplication1")]
    partial class movieapplication1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MyMovieApp.Entity.MovieModel", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MovieDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("movieModel");
                });

            modelBuilder.Entity("MyMovieApp.Entity.ShowMovieTime", b =>
                {
                    b.Property<int>("MovieTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("ShowTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThetreId")
                        .HasColumnType("int");

                    b.Property<int?>("ThetreModelThetreId")
                        .HasColumnType("int");

                    b.HasKey("MovieTimeId");

                    b.HasIndex("MovieId");

                    b.HasIndex("ThetreModelThetreId");

                    b.ToTable("MovieTime");
                });

            modelBuilder.Entity("MyMovieApp.Entity.ThetreModel", b =>
                {
                    b.Property<int>("ThetreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ThetreCapacity")
                        .HasColumnType("int");

                    b.Property<string>("ThetreLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThetreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThetreId");

                    b.ToTable("thetreModels");
                });

            modelBuilder.Entity("MyMovieApp.Entity.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mobile")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("userModel");
                });

            modelBuilder.Entity("MyMovieApp.Entity.ShowMovieTime", b =>
                {
                    b.HasOne("MyMovieApp.Entity.MovieModel", "movieModel")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyMovieApp.Entity.ThetreModel", "ThetreModel")
                        .WithMany()
                        .HasForeignKey("ThetreModelThetreId");

                    b.Navigation("movieModel");

                    b.Navigation("ThetreModel");
                });
#pragma warning restore 612, 618
        }
    }
}
