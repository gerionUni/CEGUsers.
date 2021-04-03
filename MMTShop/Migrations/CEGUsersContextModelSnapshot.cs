﻿// <auto-generated />
using System;
using CEGUsers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CEGUsers.Migrations
{
    [DbContext(typeof(CEGUsersContext))]
    partial class CEGUsersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("CEGUsers.CEGUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DOB")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Firstname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CEGUsers.UserAddresses", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CEGUserID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HouseNumber")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("PostCode")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CEGUserID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CEGUsers.UserAddresses", b =>
                {
                    b.HasOne("CEGUsers.CEGUser", null)
                        .WithMany("UserAddress")
                        .HasForeignKey("CEGUserID");
                });

            modelBuilder.Entity("CEGUsers.CEGUser", b =>
                {
                    b.Navigation("UserAddress");
                });
#pragma warning restore 612, 618
        }
    }
}
