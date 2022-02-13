namespace BACKEND.Interfaces
{
    public interface INutricaoService
    {
        Task<IEnumerable<string>> VerificarCosumoDeProdutoPorCodUsuario(int CodUsuario, string CodBarra);
    }
}