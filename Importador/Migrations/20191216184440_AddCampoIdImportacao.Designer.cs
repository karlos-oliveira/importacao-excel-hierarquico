﻿// <auto-generated />
using System;
using Importador.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Importador.Migrations
{
    [DbContext(typeof(ImportadorDbContext))]
    [Migration("20191216184440_AddCampoIdImportacao")]
    partial class AddCampoIdImportacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Importador.Models.Ambiente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdImportacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdPai")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdTipoAmbiente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ambiente");
                });

            modelBuilder.Entity("Importador.Models.ImportacaoAmbiente", b =>
                {
                    b.Property<Guid>("IdImportacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataImportacaoUTC")
                        .HasColumnType("datetime2");

                    b.HasKey("IdImportacao");

                    b.ToTable("ImportacaoAmbiente");
                });

            modelBuilder.Entity("Importador.Models.TipoAmbiente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TipoAmbiente");
                });
#pragma warning restore 612, 618
        }
    }
}
