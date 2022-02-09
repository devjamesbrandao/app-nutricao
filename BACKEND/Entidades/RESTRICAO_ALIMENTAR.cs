
namespace BACKEND.Entidades
{
    public partial class RESTRICAO_ALIMENTAR
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<RESTRICAO_INGREDIENTE> RestricaoIngredientes {get; set;}
        public virtual ICollection<USUARIO_RESTRICAO> UsuarioRestricaos {get; set;}
    }
}
