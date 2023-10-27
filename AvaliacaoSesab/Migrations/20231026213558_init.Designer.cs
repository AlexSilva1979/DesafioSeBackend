﻿// <auto-generated />
using System;
using AvaliacaoSesab.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AvaliacaoSesab.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20231026213558_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("AddressModelPersonModel", b =>
                {
                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AddressId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("AddressModelPersonModel");
                });

            modelBuilder.Entity("AvaliacaoSesab.Models.AddressModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("AvaliacaoSesab.Models.PersonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Profile")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("AvaliacaoSesab.Models.ProfileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("AvaliacaoSesab.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfileId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AddressModelPersonModel", b =>
                {
                    b.HasOne("AvaliacaoSesab.Models.AddressModel", null)
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AvaliacaoSesab.Models.PersonModel", null)
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AvaliacaoSesab.Models.UserModel", b =>
                {
                    b.HasOne("AvaliacaoSesab.Models.ProfileModel", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
