using BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BACKEND.Mappings
{
    public class ProdutoIngredienteMapping : IEntityTypeConfiguration<PRODUTO_INGREDIENTE>
    {
        public void Configure(EntityTypeBuilder<PRODUTO_INGREDIENTE> entity)
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
        }
    }
}