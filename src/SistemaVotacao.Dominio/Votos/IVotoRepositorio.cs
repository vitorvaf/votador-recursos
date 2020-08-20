using System;

namespace SistemaVotacao.Dominio.Votos
{
    public interface IVotoRepositorio
    {
        void ArmazenarVoto(Voto voto);
        Voto BuscarVotoPeloIdFuncionario(int idFuncionario);
    }
    
}