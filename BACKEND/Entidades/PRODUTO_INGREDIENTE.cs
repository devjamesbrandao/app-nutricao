
namespace BACKEND.Entidades
{
    public partial class PRODUTO_INGREDIENTE
    {
        public string FK_PRODUTO_ID { get; set; }
        public virtual PRODUTO FK_PRODUTO { get; set; }

        public string FK_INGREDIENTE_ID { get; set; }
        public virtual INGREDIENTE FK_INGREDIENTE { get; set; }
    }
}
