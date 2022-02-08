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

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.Property(e => e.CodBarra)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);
        }
    }
}