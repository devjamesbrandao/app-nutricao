namespace BACKEND.Interfaces
{
    public interface INutricaoRepository
    {
        Task<IEnumerable<string>> VerificarCosumoDeProdutoPorCodUsuario(int CodUsuario, string CodBarra);
    }
}