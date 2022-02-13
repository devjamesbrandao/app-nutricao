
namespace BACKEND.Entidades
{
    public partial class RESTRICAO_INGREDIENTE
    {
        public string FK_INGREDIENTE_ID { get; set; }
        public string FK_RESTRICAO_ALIMENTAR_ID { get; set; }

        public virtual INGREDIENTE FK_INGREDIENTE { get; set; }
        public virtual RESTRICAO_ALIMENTAR FK_RESTRICAO_ALIMENTAR { get; set; }
    }
}
