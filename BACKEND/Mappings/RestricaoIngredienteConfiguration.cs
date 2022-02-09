using BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BACKEND.Mappings
{
    public class RestricaoIngredienteMapping : IEntityTypeConfiguration<RESTRICAO_INGREDIENTE>
    {
        public void Configure(EntityTypeBuilder<RESTRICAO_INGREDIENTE> entity)
        {
            entity.HasKey(x => new {x.FK_RESTRICAO_ALIMENTAR_ID, x.FK_INGREDIENTE_ID});

            entity.ToTable("RESTRICAO_INGREDIENTE");

            entity.HasOne(d => d.FK_INGREDIENTE)
                .WithMany(x => x.RestricaoIngredientes)
                .HasForeignKey(d => d.FK_INGREDIENTE_ID)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_RESTRICAO_INGREDIENTE_1");

            entity.HasOne(d => d.FK_RESTRICAO_ALIMENTAR)
                .WithMany(x => x.RestricaoIngredientes)
                .HasForeignKey(d => d.FK_RESTRICAO_ALIMENTAR_ID)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_RESTRICAO_INGREDIENTE_2");
        }
    }
}