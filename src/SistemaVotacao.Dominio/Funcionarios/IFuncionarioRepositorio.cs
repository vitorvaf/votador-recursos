using System;
using SistemaVotacao.Dominio._Base;

namespace SistemaVotacao.Dominio.Funcionarios
{
    public interface IFuncionarioRepositorio : IRepositorio<Funcionario>
    {        
        Funcionario ObterPeloEmail(string email);
    }
}