using System;
using System.Collections.Generic;
using BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BACKEND.Scaffold
{
    public partial class NutricaoContext : DbContext
    {
        public NutricaoContext()
        {
        }

        public NutricaoContext(DbContextOptions<NutricaoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<INGREDIENTE> INGREDIENTEs { get; set; }
        public virtual DbSet<PRODUTO> PRODUTOs { get; set; }
        public virtual DbSet<PRODUTO_INGREDIENTE> PRODUTO_INGREDIENTEs { get; set; }
        public virtual DbSet<RESTRICAO_ALIMENTAR> RESTRICAO_ALIMENTARs { get; set; }
        public virtual DbSet<RESTRICAO_INGREDIENTE> RESTRICAO_INGREDIENTEs { get; set; }
        public virtual DbSet<USUARIO> USUARIOs { get; set; }
        public virtual DbSet<USUARIO_RESTRICAO> USUARIO_RESTRICAOs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PRODUTO>(entity =>
            {
                entity.ToTable("PRODUTO");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.CodBarra)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PRODUTO_INGREDIENTE>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PRODUTO_INGREDIENTE");

                entity.HasOne(d => d.FK_INGREDIENTE)
                    .WithMany()
                    .HasForeignKey(d => d.FK_INGREDIENTE_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUTO_INGREDIENTE_2");

                entity.HasOne(d => d.FK_PRODUTO)
                    .WithMany()
                    .HasForeignKey(d => d.FK_PRODUTO_ID)
                    .HasConstraintName("FK_PRODUTO_INGREDIENTE_1");
            });

            modelBuilder.Entity<RESTRICAO_ALIMENTAR>(entity =>
            {
                entity.ToTable("RESTRICAO_ALIMENTAR");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RESTRICAO_INGREDIENTE>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RESTRICAO_INGREDIENTE");

                entity.HasOne(d => d.FK_INGREDIENTE)
                    .WithMany()
                    .HasForeignKey(d => d.FK_INGREDIENTE_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESTRICAO_INGREDIENTE_1");

                entity.HasOne(d => d.FK_RESTRICAO_ALIMENTAR)
                    .WithMany()
                    .HasForeignKey(d => d.FK_RESTRICAO_ALIMENTAR_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESTRICAO_INGREDIENTE_2");
            });

            modelBuilder.Entity<USUARIO>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<USUARIO_RESTRICAO>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("USUARIO_RESTRICAO");

                entity.HasOne(d => d.FK_RESTRICAO_ALIMENTAR)
                    .WithMany()
                    .HasForeignKey(d => d.FK_RESTRICAO_ALIMENTAR_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIO_RESTRICAO_1");

                entity.HasOne(d => d.FK_USUARIO)
                    .WithMany()
                    .HasForeignKey(d => d.FK_USUARIO_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIO_RESTRICAO_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
