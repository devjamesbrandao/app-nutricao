
namespace BACKEND.DTO
{
    public class Produto
    {
        public string IdProduto {get; set;}
        public string CodBarras {get; set;}
        public string UrlImagem {get; set;}
        public string Titulo {get; set;}
        public string Marca {get; set;}
        public string Descricao {get; set;}
        public List<string> Ingredientes {get; set;}
    }
}