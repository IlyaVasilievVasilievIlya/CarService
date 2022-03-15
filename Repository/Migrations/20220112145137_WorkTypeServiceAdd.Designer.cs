﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repository.Data;

namespace Repository.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220112145137_WorkTypeServiceAdd")]
    partial class WorkTypeServiceAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Business.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer");

                    b.Property<int>("ManufactureYear")
                        .HasColumnType("integer");

                    b.Property<int?>("ModelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ModelId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Business.Entities.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("Business.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Business.Entities.ClientCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CarId")
                        .HasColumnType("integer");

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientCars");
                });

            modelBuilder.Entity("Business.Entities.GarageOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClientCarId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalSum")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientCarId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Business.Entities.Mechanic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Mechanics");
                });

            modelBuilder.Entity("Business.Entities.OrderPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<int?>("MechanicId")
                        .HasColumnType("integer");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int?>("WorkId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MechanicId");

                    b.HasIndex("OrderId");

                    b.HasIndex("WorkId");

                    b.ToTable("OrderPositions");
                });

            modelBuilder.Entity("Business.Entities.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int?>("WorkTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkTypeId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("Business.Entities.WorkType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WorkTypes");
                });

            modelBuilder.Entity("MechanicWorkType", b =>
                {
                    b.Property<int>("MechanicsId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkScopeId")
                        .HasColumnType("integer");

                    b.HasKey("MechanicsId", "WorkScopeId");

                    b.HasIndex("WorkScopeId");

                    b.ToTable("MechanicWorkType");
                });

            modelBuilder.Entity("Business.Entities.Car", b =>
                {
                    b.HasOne("Business.Entities.Client", null)
                        .WithMany("Cars")
                        .HasForeignKey("ClientId");

                    b.HasOne("Business.Entities.CarModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Business.Entities.ClientCar", b =>
                {
                    b.HasOne("Business.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("Business.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("Car");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Business.Entities.GarageOrder", b =>
                {
                    b.HasOne("Business.Entities.ClientCar", "ClientCar")
                        .WithMany()
                        .HasForeignKey("ClientCarId");

                    b.Navigation("ClientCar");
                });

            modelBuilder.Entity("Business.Entities.OrderPosition", b =>
                {
                    b.HasOne("Business.Entities.Mechanic", "Mechanic")
                        .WithMany()
                        .HasForeignKey("MechanicId");

                    b.HasOne("Business.Entities.GarageOrder", "Order")
                        .WithMany("Positions")
                        .HasForeignKey("OrderId");

                    b.HasOne("Business.Entities.Work", "Work")
                        .WithMany()
                        .HasForeignKey("WorkId");

                    b.Navigation("Mechanic");

                    b.Navigation("Order");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("Business.Entities.Work", b =>
                {
                    b.HasOne("Business.Entities.WorkType", "WorkType")
                        .WithMany()
                        .HasForeignKey("WorkTypeId");

                    b.Navigation("WorkType");
                });

            modelBuilder.Entity("MechanicWorkType", b =>
                {
                    b.HasOne("Business.Entities.Mechanic", null)
                        .WithMany()
                        .HasForeignKey("MechanicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Business.Entities.WorkType", null)
                        .WithMany()
                        .HasForeignKey("WorkScopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Business.Entities.Client", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Business.Entities.GarageOrder", b =>
                {
                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
