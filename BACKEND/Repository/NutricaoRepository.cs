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

        /*
        SELECT I.Descricao FROM USUARIO U
        INNER JOIN USUARIO_RESTRICAO UR ON U.ID = UR.FK_USUARIO_ID
        INNER JOIN RESTRICAO_ALIMENTAR RA ON UR.FK_RESTRICAO_ALIMENTAR_ID = RA.ID
        INNER JOIN RESTRICAO_INGREDIENTE RI ON RA.ID = RI.FK_RESTRICAO_ALIMENTAR_ID
        INNER JOIN INGREDIENTE I ON RI.FK_INGREDIENTE_ID = I.ID
        INNER JOIN PRODUTO_INGREDIENTE PI ON I.ID = PI.FK_INGREDIENTE_ID
        INNER JOIN PRODUTO P ON PI.FK_PRODUTO_ID = P.ID
        WHERE P.CodBarra = '7898594710534' AND U.ID = 1
        */

        public async Task<IEnumerable<string>> VerificarCosumoDeProdutoPorCodUsuario(
            int CodUsuario, string CodBarra
        )
        {
            return new List<string>{"TEste"};
        }
    }
}