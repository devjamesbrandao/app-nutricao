
namespace BACKEND.Entidades
{
    public partial class USUARIO
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<USUARIO_RESTRICAO> UsuarioRestricaos {get; set;}
    }
}
