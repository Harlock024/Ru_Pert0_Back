﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ru_pert0_back.api.Context;

#nullable disable

namespace ru_pert0_back.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241102074543_initial_Migration_models_v2")]
    partial class initial_Migration_models_v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ru_pert0_back.api.Models.Node", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<long>("TaskId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK_Node");

                    b.HasIndex("ParentId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TaskId")
                        .IsUnique();

                    b.ToTable("Node", (string)null);
                });

            modelBuilder.Entity("ru_pert0_back.api.Models.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK_Project");

                    b.HasIndex("UserId");

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("ru_pert0_back.api.Models.Task", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Duration")
                        .HasColumnType("double precision");

                    b.Property<double>("MostLikelyTime")
                        .HasColumnType("double precision");

                    b.Property<double>("OptimisticTime")
                        .HasColumnType("double precision");

                    b.Property<double>("PessimisticTime")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ru_pert0_back.api.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_User");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ru_pert0_back.api.Models.Node", b =>
                {
                    b.HasOne("ru_pert0_back.api.Models.Node", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ru_pert0_back.api.Models.Project", "Project")
                        .WithMany("Nodes")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ru_pert0_back.api.Models.Task", "Task")
                        .WithOne()
                        .HasForeignKey("ru_pert0_back.api.Models.Node", "TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Project");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("ru_pert0_back.api.Models.Project", b =>
                {
                    b.HasOne("ru_pert0_back.api.Models.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ru_pert0_back.api.Models.Node", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("ru_pert0_back.api.Models.Project", b =>
                {
                    b.Navigation("Nodes");
                });

            modelBuilder.Entity("ru_pert0_back.api.Models.User", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
