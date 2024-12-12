﻿// <auto-generated />
using System;
using CacaCaracteres.ContextoDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CacaCaracteres.Migrations
{
    [DbContext(typeof(AppDataBaseContext))]
    partial class AppDataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CacaCaracteres.Modelo.Autor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Autors");
                });

            modelBuilder.Entity("CacaCaracteres.Modelo.LivroTexto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CodigoTexto")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("LivroTexto");
                });

            modelBuilder.Entity("CacaCaracteres.Modelo.LivroTexto", b =>
                {
                    b.HasOne("CacaCaracteres.Modelo.Autor", "Autor")
                        .WithMany("LivroTexto")
                        .HasForeignKey("AutorId");

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("CacaCaracteres.Modelo.Autor", b =>
                {
                    b.Navigation("LivroTexto");
                });
#pragma warning restore 612, 618
        }
    }
}
