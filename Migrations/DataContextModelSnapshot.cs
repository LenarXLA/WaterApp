﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WaterApp.Model;

#nullable disable

namespace WaterApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("WaterApp.Model.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CurrentDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Volume")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Historys");
                });
#pragma warning restore 612, 618
        }
    }
}