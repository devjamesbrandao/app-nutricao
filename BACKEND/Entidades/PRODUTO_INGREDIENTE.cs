
namespace BACKEND.Entidades
{
    public partial class PRODUTO_INGREDIENTE
    {
        public int FK_PRODUTO_ID { get; set; }
        public virtual PRODUTO FK_PRODUTO { get; set; }

        public int FK_INGREDIENTE_ID { get; set; }
        public virtual INGREDIENTE FK_INGREDIENTE { get; set; }
    }
}
