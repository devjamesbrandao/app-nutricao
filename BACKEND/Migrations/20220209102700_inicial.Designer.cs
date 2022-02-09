﻿// <auto-generated />
using System;
using BACKEND.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BACKEND.Migrations
{
    [DbContext(typeof(NutricaoContext))]
    [Migration("20220209102700_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BACKEND.Entidades.INGREDIENTE", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("ID");

                    b.ToTable("INGREDIENTE", (string)null);
                });

            modelBuilder.Entity("BACKEND.Entidades.PRODUTO", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("CodBarra")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nome")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("ID");

                    b.ToTable("PRODUTO", (string)null);
                });

            modelBuilder.Entity("BACKEND.Entidades.PRODUTO_INGREDIENTE", b =>
                {
                    b.Property<int>("FK_INGREDIENTE_ID")
                        .HasColumnType("int");

                    b.Property<int?>("FK_PRODUTO_ID")
                        .HasColumnType("int");

                    b.HasIndex("FK_INGREDIENTE_ID");

                    b.HasIndex("FK_PRODUTO_ID");

                    b.ToTable("PRODUTO_INGREDIENTE", (string)null);
                });

            modelBuilder.Entity("BACKEND.Entidades.RESTRICAO_ALIMENTAR", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("ID");

                    b.ToTable("RESTRICAO_ALIMENTAR", (string)null);
                });

            modelBuilder.Entity("BACKEND.Entidades.RESTRICAO_INGREDIENTE", b =>
                {
                    b.Property<int>("FK_INGREDIENTE_ID")
                        .HasColumnType("int");

                    b.Property<int>("FK_RESTRICAO_ALIMENTAR_ID")
                        .HasColumnType("int");

                    b.HasIndex("FK_INGREDIENTE_ID");

                    b.HasIndex("FK_RESTRICAO_ALIMENTAR_ID");

                    b.ToTable("RESTRICAO_INGREDIENTE", (string)null);
                });

            modelBuilder.Entity("BACKEND.Entidades.USUARIO", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("ID");

                    b.ToTable("USUARIO", (string)null);
                });

            modelBuilder.Entity("BACKEND.Entidades.USUARIO_RESTRICAO", b =>
                {
                    b.Property<int>("FK_RESTRICAO_ALIMENTAR_ID")
                        .HasColumnType("int");

                    b.Property<int>("FK_USUARIO_ID")
                        .HasColumnType("int");

                    b.HasIndex("FK_RESTRICAO_ALIMENTAR_ID");

                    b.HasIndex("FK_USUARIO_ID");

                    b.ToTable("USUARIO_RESTRICAO", (string)null);
                });

            modelBuilder.Entity("BACKEND.Entidades.PRODUTO_INGREDIENTE", b =>
                {
                    b.HasOne("BACKEND.Entidades.INGREDIENTE", "FK_INGREDIENTE")
                        .WithMany()
                        .HasForeignKey("FK_INGREDIENTE_ID")
                        .IsRequired()
                        .HasConstraintName("FK_PRODUTO_INGREDIENTE_2");

                    b.HasOne("BACKEND.Entidades.PRODUTO", "FK_PRODUTO")
                        .WithMany()
                        .HasForeignKey("FK_PRODUTO_ID")
                        .HasConstraintName("FK_PRODUTO_INGREDIENTE_1");

                    b.Navigation("FK_INGREDIENTE");

                    b.Navigation("FK_PRODUTO");
                });

            modelBuilder.Entity("BACKEND.Entidades.RESTRICAO_INGREDIENTE", b =>
                {
                    b.HasOne("BACKEND.Entidades.INGREDIENTE", "FK_INGREDIENTE")
                        .WithMany()
                        .HasForeignKey("FK_INGREDIENTE_ID")
                        .IsRequired()
                        .HasConstraintName("FK_RESTRICAO_INGREDIENTE_1");

                    b.HasOne("BACKEND.Entidades.RESTRICAO_ALIMENTAR", "FK_RESTRICAO_ALIMENTAR")
                        .WithMany()
                        .HasForeignKey("FK_RESTRICAO_ALIMENTAR_ID")
                        .IsRequired()
                        .HasConstraintName("FK_RESTRICAO_INGREDIENTE_2");

                    b.Navigation("FK_INGREDIENTE");

                    b.Navigation("FK_RESTRICAO_ALIMENTAR");
                });

            modelBuilder.Entity("BACKEND.Entidades.USUARIO_RESTRICAO", b =>
                {
                    b.HasOne("BACKEND.Entidades.RESTRICAO_ALIMENTAR", "FK_RESTRICAO_ALIMENTAR")
                        .WithMany()
                        .HasForeignKey("FK_RESTRICAO_ALIMENTAR_ID")
                        .IsRequired()
                        .HasConstraintName("FK_USUARIO_RESTRICAO_1");

                    b.HasOne("BACKEND.Entidades.USUARIO", "FK_USUARIO")
                        .WithMany()
                        .HasForeignKey("FK_USUARIO_ID")
                        .IsRequired()
                        .HasConstraintName("FK_USUARIO_RESTRICAO_2");

                    b.Navigation("FK_RESTRICAO_ALIMENTAR");

                    b.Navigation("FK_USUARIO");
                });
#pragma warning restore 612, 618
        }
    }
}
