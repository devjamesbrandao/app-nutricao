using BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BACKEND.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<USUARIO>
    {
        public void Configure(EntityTypeBuilder<USUARIO> entity)
        {
            entity.ToTable("USUARIO");

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);
        }
    }
}