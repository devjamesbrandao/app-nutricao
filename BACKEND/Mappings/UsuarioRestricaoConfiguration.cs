using BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BACKEND.Mappings
{
    public class UsuarioRestricaoMapping : IEntityTypeConfiguration<USUARIO_RESTRICAO>
    {
        public void Configure(EntityTypeBuilder<USUARIO_RESTRICAO> entity)
        {
            entity.HasKey(x => new { x.FK_RESTRICAO_ALIMENTAR_ID, x.FK_USUARIO_ID });

            entity.ToTable("USUARIO_RESTRICAO");

            entity.HasOne(d => d.FK_RESTRICAO_ALIMENTAR)
                .WithMany(x => x.UsuarioRestricaos)
                .HasForeignKey(d => d.FK_RESTRICAO_ALIMENTAR_ID)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_USUARIO_RESTRICAO_1");

            entity.HasOne(d => d.FK_USUARIO)
                .WithMany(x => x.UsuarioRestricaos)
                .HasForeignKey(d => d.FK_USUARIO_ID)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_USUARIO_RESTRICAO_2");
        }
    }
}