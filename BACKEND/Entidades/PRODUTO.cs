
namespace BACKEND.Entidades
{
    public partial class PRODUTO
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public string CodBarra { get; set; }
        public string fk_marca_id {get; set;}
        public virtual Marca fk_Marca {get; set;}
        public virtual ICollection<PRODUTO_INGREDIENTE> ProdutosIngredientes {get; set;}
    }
}
