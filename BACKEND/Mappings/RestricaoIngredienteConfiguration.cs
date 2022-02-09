using BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BACKEND.Mappings
{
    public class RestricaoIngredienteMapping : IEntityTypeConfiguration<RESTRICAO_INGREDIENTE>
    {
        public void Configure(EntityTypeBuilder<RESTRICAO_INGREDIENTE> entity)
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
        }
    }
}