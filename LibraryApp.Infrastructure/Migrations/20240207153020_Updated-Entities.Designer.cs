﻿// <auto-generated />
using System;
using LibraryApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryApp.Infrastructure.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240207153020_Updated-Entities")]
    partial class UpdatedEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryApp.Infrastructure.Entities.BookCategoryEntity", b =>
                {
                    b.Property<int>("BookCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookCategoryID"));

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("BookCategoryID");

                    b.HasIndex("BookID");

                    b.HasIndex("CategoryID");

                    b.ToTable("BookCategories");
                });

            modelBuilder.Entity("LibraryApp.Infrastructure.Entities.BookEntity", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Published_Year")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("BookID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryApp.Infrastructure.Entities.BorrowedBookEntity", b =>
                {
                    b.Property<int>("BorrowID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BorrowID"));

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BorrowID");

                    b.HasIndex("BookID");

                    b.HasIndex("UserID");

                    b.ToTable("BorrowedBooks");
                });

            modelBuilder.Entity("LibraryApp.Infrastructure.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LibraryApp.Infrastructure.Entities.UserEntity", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phonenumber")
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("UserID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibraryApp.Infrastructure.Entities.BookCategoryEntity", b =>
                {
                    b.HasOne("LibraryApp.Infrastructure.Entities.BookEntity", "Book")
                        .WithMany("BookCategories")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApp.Infrastructure.Entities.CategoryEntity", "Category")
                        .WithMany("BookCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LibraryApp.Infrastructure.Entities.BorrowedBookEntity", b =>
                {
                    b.HasOne("LibraryApp.Infrastructure.Entities.BookEntity", "Book")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApp.Infrastructure.Entities.UserEntity", "User")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryApp.Infrastructure.Entities.BookEntity", b =>
                {
                    b.Navigation("BookCategories");

                    b.Navigation("BorrowedBooks");
                });

            modelBuilder.Entity("LibraryApp.Infrastructure.Entities.CategoryEntity", b =>
                {
                    b.Navigation("BookCategories");
                });

            modelBuilder.Entity("LibraryApp.Infrastructure.Entities.UserEntity", b =>
                {
                    b.Navigation("BorrowedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
