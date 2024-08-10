﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TreeNodeException.Api.Models;

#nullable disable

namespace TreeNodeException.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TreeNodeException.Api.Models.ExceptionLog", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EventID"));

                    b.Property<string>("ExceptionMessage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExceptionType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RequestBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RequestParameters")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StackTrace")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("EventID");

                    b.ToTable("ExceptionLogs");
                });

            modelBuilder.Entity("TreeNodeException.Api.Models.Node", b =>
                {
                    b.Property<int>("NodeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NodeID"));

                    b.Property<string>("NodeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentNodeID")
                        .HasColumnType("integer");

                    b.Property<int>("TreeID")
                        .HasColumnType("integer");

                    b.HasKey("NodeID");

                    b.HasIndex("ParentNodeID");

                    b.HasIndex("TreeID");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("TreeNodeException.Api.Models.Tree", b =>
                {
                    b.Property<int>("TreeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TreeID"));

                    b.Property<string>("TreeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TreeID");

                    b.ToTable("Trees");
                });

            modelBuilder.Entity("TreeNodeException.Api.Models.Node", b =>
                {
                    b.HasOne("TreeNodeException.Api.Models.Node", "ParentNode")
                        .WithMany("ChildNodes")
                        .HasForeignKey("ParentNodeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TreeNodeException.Api.Models.Tree", "Tree")
                        .WithMany("Nodes")
                        .HasForeignKey("TreeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentNode");

                    b.Navigation("Tree");
                });

            modelBuilder.Entity("TreeNodeException.Api.Models.Node", b =>
                {
                    b.Navigation("ChildNodes");
                });

            modelBuilder.Entity("TreeNodeException.Api.Models.Tree", b =>
                {
                    b.Navigation("Nodes");
                });
#pragma warning restore 612, 618
        }
    }
}
