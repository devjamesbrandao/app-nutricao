
namespace BACKEND.Entidades
{
    public partial class INGREDIENTE
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<PRODUTO_INGREDIENTE> ProdutosIngredientes {get; set;}
        public virtual ICollection<RESTRICAO_INGREDIENTE> RestricaoIngredientes {get; set;}
    }
}
