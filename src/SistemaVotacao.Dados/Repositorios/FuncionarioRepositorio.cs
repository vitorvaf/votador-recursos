using System;
using System.Collections.Generic;
using System.Linq;
using SistemaVotacao.Dados.Contextos;
using SistemaVotacao.Dominio.Funcionarios;

namespace SistemaVotacao.Dados.Repositorios
{
    public class FuncionarioRepositorio : RepositorioBase<Funcionario>, IFuncionarioRepositorio
    {
        public FuncionarioRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public Funcionario ObterPeloEmail(string email)
        {
            var entidade = Context.Set<Funcionario>()
                .Where(funcionario => funcionario.Email == email);

            if(entidade.Any())
                return entidade.First();
            
            return null;
        }
    }

}