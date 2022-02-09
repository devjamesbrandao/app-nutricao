using BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BACKEND.Mappings
{
    public class RestricaoMapping : IEntityTypeConfiguration<RESTRICAO_ALIMENTAR>
    {
        public void Configure(EntityTypeBuilder<RESTRICAO_ALIMENTAR> entity)
        {
            entity.ToTable("RESTRICAO_ALIMENTAR");

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.Property(e => e.Descricao)
                .HasMaxLength(250)
                .IsUnicode(false);
        }
    }
}