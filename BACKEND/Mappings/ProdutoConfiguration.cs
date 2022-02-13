using BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BACKEND.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<PRODUTO>
    {
        public void Configure(EntityTypeBuilder<PRODUTO> entity)
        {
            entity.ToTable("PRODUTO");

            entity.HasKey(x => x.ID);

            entity.Property(e => e.ID).ValueGeneratedNever().HasMaxLength(50);

            entity.Property(e => e.CodBarra)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.fk_Marca)
                .WithMany(x => x.Produtos)
                .HasForeignKey(d => d.fk_marca_id)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_MARCA_ID");
        }
    }
}