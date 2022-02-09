
namespace BACKEND.Entidades
{
    public partial class USUARIO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<USUARIO_RESTRICAO> UsuarioRestricaos {get; set;}
    }
}
