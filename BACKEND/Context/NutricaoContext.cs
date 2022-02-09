using BACKEND.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Context
{
    public partial class NutricaoContext : DbContext
    {
        public NutricaoContext()
        {
        }

        public NutricaoContext(DbContextOptions<NutricaoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<INGREDIENTE> INGREDIENTEs { get; set; }
        public virtual DbSet<PRODUTO> PRODUTOs { get; set; }
        public virtual DbSet<PRODUTO_INGREDIENTE> PRODUTO_INGREDIENTEs { get; set; }
        public virtual DbSet<RESTRICAO_ALIMENTAR> RESTRICAO_ALIMENTARs { get; set; }
        public virtual DbSet<RESTRICAO_INGREDIENTE> RESTRICAO_INGREDIENTEs { get; set; }
        public virtual DbSet<USUARIO> USUARIOs { get; set; }
        public virtual DbSet<USUARIO_RESTRICAO> USUARIO_RESTRICAOs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NutricaoContext).Assembly);
        }
    }
}
