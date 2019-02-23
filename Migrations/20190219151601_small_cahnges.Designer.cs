﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Plant.API.data;

namespace Plant.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190219151601_small_cahnges")]
    partial class small_cahnges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("Plant.API.models.Info", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdminsNumber");

                    b.Property<double>("HowMuchDone");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<bool>("ReadyToUse");

                    b.Property<int>("UsersNumber");

                    b.Property<string>("Version");

                    b.HasKey("id");

                    b.ToTable("Infos");
                });

            modelBuilder.Entity("Plant.API.models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Hash");

                    b.Property<byte[]>("Salt");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Plant.API.models.Value", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Values");
                });
#pragma warning restore 612, 618
        }
    }
}
