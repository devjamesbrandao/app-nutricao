using BACKEND.Context;
using BACKEND.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Repository
{
    public class NutricaoRepository : INutricaoRepository
    {
        private readonly NutricaoContext _context;

        public NutricaoRepository(NutricaoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> VerificarCosumoDeProdutoPorCodUsuario(
            int CodUsuario, int CodProd
        )
        {
            return await (
                from u in _context.USUARIOs
                join ur in _context.USUARIO_RESTRICAOs
                on u.ID equals ur.FK_USUARIO_ID
                select u.Nome
            ).ToListAsync();
        }
    }
}