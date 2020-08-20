using System;
using SistemaVotacao.Dominio._Base;

namespace SistemaVotacao.Dominio.Votos
{
    public interface IVotoRepositorio : IRepositorio<Voto>
    {
        Voto BuscarVotoPeloIdFuncionario(int idFuncionario);
    }
    
}