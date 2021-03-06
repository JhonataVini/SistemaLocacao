﻿// <auto-generated />
using System;
using CrudSistema.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SistemaLocacao.Migrations
{
    [DbContext(typeof(ClienteContext))]
    [Migration("20200821155626_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrudSistema.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF");

                    b.Property<string>("Nome");

                    b.HasKey("IdCliente");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("CrudSistema.Models.Filme", b =>
                {
                    b.Property<int>("IdFilme")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Titulo")
                        .HasMaxLength(30);

                    b.HasKey("IdFilme");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("CrudSistema.Models.Locacao", b =>
                {
                    b.Property<int>("IdLocacao")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataDevolucao");

                    b.Property<DateTime>("DataEntrega");

                    b.Property<DateTime>("DataLocacao");

                    b.Property<int>("IdCliente");

                    b.Property<int>("IdFilme");

                    b.HasKey("IdLocacao");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdFilme");

                    b.ToTable("Locacoes");
                });

            modelBuilder.Entity("CrudSistema.Models.Locacao", b =>
                {
                    b.HasOne("CrudSistema.Models.Cliente", "Clientes")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrudSistema.Models.Filme", "Filmes")
                        .WithMany()
                        .HasForeignKey("IdFilme")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
