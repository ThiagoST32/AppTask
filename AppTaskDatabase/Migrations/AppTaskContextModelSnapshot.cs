﻿// <auto-generated />
using System;
using AppTaskDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppTaskDatabase.Migrations
{
    [DbContext(typeof(AppTaskContext))]
    partial class AppTaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("AppTask.Models.SubTaskModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TaskModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TaskModelId");

                    b.ToTable("SubPropertys");
                });

            modelBuilder.Entity("AppTask.Models.TaskModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Create")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FinalDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("AppTask.Models.SubTaskModel", b =>
                {
                    b.HasOne("AppTask.Models.TaskModel", null)
                        .WithMany("SubTasks")
                        .HasForeignKey("TaskModelId");
                });

            modelBuilder.Entity("AppTask.Models.TaskModel", b =>
                {
                    b.Navigation("SubTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
