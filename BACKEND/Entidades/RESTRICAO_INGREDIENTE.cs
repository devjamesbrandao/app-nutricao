
namespace BACKEND.Entidades
{
    public partial class RESTRICAO_INGREDIENTE
    {
        public int FK_INGREDIENTE_ID { get; set; }
        public int FK_RESTRICAO_ALIMENTAR_ID { get; set; }

        public virtual INGREDIENTE FK_INGREDIENTE { get; set; }
        public virtual RESTRICAO_ALIMENTAR FK_RESTRICAO_ALIMENTAR { get; set; }
    }
}
