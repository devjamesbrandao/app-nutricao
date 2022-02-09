using BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BACKEND.Mappings
{
    public class UsuarioRestricaoMapping : IEntityTypeConfiguration<USUARIO_RESTRICAO>
    {
        public void Configure(EntityTypeBuilder<USUARIO_RESTRICAO> entity)
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
        }
    }
}