﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApi.Infrastructure.Data;

#nullable disable

namespace ToDoApi.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241105062235_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDoApi.Domain.Entities.MiniAppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Initdata")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("MiniAppUsers");
                });

            modelBuilder.Entity("ToDoApi.Domain.Entities.MiniAppUserContact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ContactRequest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<long>("MiniAppUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MiniAppUserId")
                        .IsUnique();

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ToDoApi.Domain.Entities.ToDoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Context")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TodoItems", t =>
                        {
                            t.HasCheckConstraint("CK_UserIdOrPhoneNumber", "[UserId] IS NOT NULL OR [UserPhoneNumber] IS NOT NULL");
                        });
                });

            modelBuilder.Entity("ToDoApi.Domain.Entities.UserProfile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("MiniAppUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("WebAppUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MiniAppUserId");

                    b.HasIndex("WebAppUserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("ToDoApi.Domain.Entities.WebAppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Otp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WebAppUsers");
                });

            modelBuilder.Entity("ToDoApi.Domain.Entities.MiniAppUserContact", b =>
                {
                    b.HasOne("ToDoApi.Domain.Entities.MiniAppUser", "MiniAppUser")
                        .WithOne("Contact")
                        .HasForeignKey("ToDoApi.Domain.Entities.MiniAppUserContact", "MiniAppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MiniAppUser");
                });

            modelBuilder.Entity("ToDoApi.Domain.Entities.UserProfile", b =>
                {
                    b.HasOne("ToDoApi.Domain.Entities.MiniAppUser", "MiniAppUser")
                        .WithMany()
                        .HasForeignKey("MiniAppUserId");

                    b.HasOne("ToDoApi.Domain.Entities.WebAppUser", "WebAppUser")
                        .WithMany()
                        .HasForeignKey("WebAppUserId");

                    b.Navigation("MiniAppUser");

                    b.Navigation("WebAppUser");
                });

            modelBuilder.Entity("ToDoApi.Domain.Entities.MiniAppUser", b =>
                {
                    b.Navigation("Contact")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
