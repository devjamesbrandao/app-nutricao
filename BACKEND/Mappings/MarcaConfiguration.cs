
using BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BACKEND.Mappings
{
    public class MarcaMapping : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> entity)
        {
            entity.ToTable("MARCA");

            entity.HasKey(x => x.Id);

            entity.Property(e => e.Id).ValueGeneratedNever().HasMaxLength(50);

            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}