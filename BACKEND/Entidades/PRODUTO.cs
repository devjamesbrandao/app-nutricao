
namespace BACKEND.Entidades
{
    public partial class PRODUTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CodBarra { get; set; }
        public virtual ICollection<PRODUTO_INGREDIENTE> ProdutosIngredientes {get; set;}
    }
}
