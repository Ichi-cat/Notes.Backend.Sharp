﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notes.Persistence;

namespace Notes.Api.Migrations
{
    [DbContext(typeof(NotesDbContext))]
    [Migration("20220816070431_Add color field")]
    partial class Addcolorfield
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("Notes.Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Notes.Domain.Matrix", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Matrices");
                });

            modelBuilder.Entity("Notes.Domain.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Notes.Domain.NoteTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<byte?>("MatrixId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte?>("ProgressConditionId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Seconds")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MatrixId");

                    b.HasIndex("ProgressConditionId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Notes.Domain.ProgressCondition", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProgressConditions");
                });

            modelBuilder.Entity("Notes.Domain.Note", b =>
                {
                    b.HasOne("Notes.Domain.Category", "Category")
                        .WithMany("Notes")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Notes.Domain.NoteTask", b =>
                {
                    b.HasOne("Notes.Domain.Matrix", "Matrix")
                        .WithMany()
                        .HasForeignKey("MatrixId");

                    b.HasOne("Notes.Domain.ProgressCondition", "ProgressCondition")
                        .WithMany()
                        .HasForeignKey("ProgressConditionId");

                    b.Navigation("Matrix");

                    b.Navigation("ProgressCondition");
                });

            modelBuilder.Entity("Notes.Domain.Category", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
