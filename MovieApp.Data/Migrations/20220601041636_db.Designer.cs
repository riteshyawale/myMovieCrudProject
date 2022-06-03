﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieApp.Data.DataConnection;

namespace MovieApp.Data.Migrations
{
    [DbContext(typeof(MovieDBContext))]
    [Migration("20220601041636_db")]
    partial class db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MovieApp.Entity.MovieModel", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MovieDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("movieModel");
                });

            modelBuilder.Entity("MovieApp.Entity.MovieShowTimeModel", b =>
                {
                    b.Property<int>("ShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("ShowTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheatreId")
                        .HasColumnType("int");

                    b.HasKey("ShowId");

                    b.HasIndex("MovieId");

                    b.HasIndex("TheatreId");

                    b.ToTable("movieShowTimeModel");
                });

            modelBuilder.Entity("MovieApp.Entity.TheatreModel", b =>
                {
                    b.Property<int>("tId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("tAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tCapacity")
                        .HasColumnType("int");

                    b.Property<string>("tClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tId");

                    b.ToTable("theatreModel");
                });

            modelBuilder.Entity("MovieApp.Entity.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mobile")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("userModel");
                });

            modelBuilder.Entity("MovieApp.Entity.MovieShowTimeModel", b =>
                {
                    b.HasOne("MovieApp.Entity.MovieModel", "movieModel")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieApp.Entity.TheatreModel", "theatreModel")
                        .WithMany()
                        .HasForeignKey("TheatreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("movieModel");

                    b.Navigation("theatreModel");
                });
#pragma warning restore 612, 618
        }
    }
}
