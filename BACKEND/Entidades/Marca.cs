
namespace BACKEND.Entidades
{
    public partial class Marca
    {
        public string Id {get; set;}
        public string Descricao {get; set;}
        public virtual ICollection<PRODUTO> Produtos {get; set;}
    }
}