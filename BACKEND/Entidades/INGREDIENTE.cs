
namespace BACKEND.Entidades
{
    public partial class INGREDIENTE
    {
        public string ID { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<PRODUTO_INGREDIENTE> ProdutosIngredientes {get; set;}
        public virtual ICollection<RESTRICAO_INGREDIENTE> RestricaoIngredientes {get; set;}
    }
}
