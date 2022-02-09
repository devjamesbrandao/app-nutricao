using BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BACKEND.Mappings
{
    public class ProdutoIngredienteMapping : IEntityTypeConfiguration<PRODUTO_INGREDIENTE>
    {
        public void Configure(EntityTypeBuilder<PRODUTO_INGREDIENTE> entity)
        {
            entity.HasKey(x => new { x.FK_INGREDIENTE_ID, x.FK_PRODUTO_ID });

            entity.ToTable("PRODUTO_INGREDIENTE");

            entity.HasOne(d => d.FK_INGREDIENTE)
                .WithMany(x => x.ProdutosIngredientes)
                .HasForeignKey(d => d.FK_INGREDIENTE_ID)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_PRODUTO_INGREDIENTE_2");

            entity.HasOne(d => d.FK_PRODUTO)
                .WithMany(x => x.ProdutosIngredientes)
                .HasForeignKey(d => d.FK_PRODUTO_ID)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_PRODUTO_INGREDIENTE_1");
        }
    }
}