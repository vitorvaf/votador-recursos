using System;
using SistemaVotacao.Dominio.Funcionarios;
using SistemaVotacao.DominioTest.Funcionarios;

namespace SistemaVotacao.DominioTest._Builder
{
    public class FuncionarioBuilder
    {
        private string _nome = "Jose da Silva";
        private string _email = "email@email.com";        
        private string _senha = "123123123";

        public static FuncionarioBuilder Novo()
        {
            return new FuncionarioBuilder();
        }

        public FuncionarioBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public FuncionarioBuilder ComEmail(string email)
        {
            _email = email;
            return this;
        }

        public FuncionarioBuilder ComFilialId(int filialId)
        {
            // _filialId = filialId;
            return this;
        }

        public FuncionarioBuilder ComSenha(string senha)
        {
            _senha = senha;
            return this;
        }

        public Funcionario Build()
        {
            return new Funcionario(_nome,_email,_senha);
        }

    }

}