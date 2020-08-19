using System;


namespace SistemaVotacao.Dominio.Funcionario
{
    public interface IFuncionarioRepositorio
    {
        void Adicionar(Funcionario funcionario);
        Funcionario ObterPeloEmail(string email);
    }
}