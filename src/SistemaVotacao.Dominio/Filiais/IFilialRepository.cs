using System;

namespace SistemaVotacao.Dominio.Filiais
{
    public interface IFilialRepositorio
    {
        void Adicionar(Filial filial);
        Filial BuscarPorNome(string nome);
    }
}


