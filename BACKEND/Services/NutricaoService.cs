using BACKEND.Interfaces;

namespace BACKEND.Services
{
    public class NutricaoService : INutricaoService
    {
        private readonly INutricaoRepository _repository;

        public NutricaoService(INutricaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<string>> VerificarCosumoDeProdutoPorCodUsuario(
            int CodUsuario, int CodProd
        )
        {
            return await _repository.VerificarCosumoDeProdutoPorCodUsuario(CodUsuario, CodProd);
        }
    }
}