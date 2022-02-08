using BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BACKEND.Mappings
{
    public class IngredienteMapping : IEntityTypeConfiguration<INGREDIENTE>
    {
        public void Configure(EntityTypeBuilder<INGREDIENTE> entity)
        {
            entity.ToTable("INGREDIENTE");

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.Property(e => e.Descricao)
                .HasMaxLength(250)
                .IsUnicode(false);
        }
    }
}