﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MvcCrudApp.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20240521101121_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("MvcCrudApp.Models.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4a77fd52-ab57-445f-81b0-743a68555fd4"),
                            Email = "johndoe@gmail.com",
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = new Guid("c089fb6e-73bd-4138-90a5-c52296105344"),
                            Email = "janedoe@gmail.com",
                            FirstName = "Jane",
                            LastName = "Doe"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
