
namespace BACKEND.Entidades
{
    public partial class USUARIO_RESTRICAO
    {
        public int FK_RESTRICAO_ALIMENTAR_ID { get; set; }
        public int FK_USUARIO_ID { get; set; }

        public virtual RESTRICAO_ALIMENTAR FK_RESTRICAO_ALIMENTAR { get; set; }
        public virtual USUARIO FK_USUARIO { get; set; }
    }
}
