﻿// <auto-generated />
using System;
using AspNotes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AspNotes.Migrations
{
    [DbContext(typeof(AspNotesContext))]
    [Migration("20231210192206_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AspNotes.Models.Nota", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("corpo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("pastaId")
                        .HasColumnType("uuid");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("pastaId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("AspNotes.Models.Pasta", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Pastas");
                });

            modelBuilder.Entity("AspNotes.Models.Usuario", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.Property<string>("senha")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AspNotes.Models.Nota", b =>
                {
                    b.HasOne("AspNotes.Models.Pasta", "pasta")
                        .WithMany("Notas")
                        .HasForeignKey("pastaId");

                    b.Navigation("pasta");
                });

            modelBuilder.Entity("AspNotes.Models.Pasta", b =>
                {
                    b.Navigation("Notas");
                });
#pragma warning restore 612, 618
        }
    }
}
