using System;
using SistemaVotacao.Dominio.Funcionario;
using SistemaVotacao.DominioTest.Funcionarios;

namespace SistemaVotacao.DominioTest._Builder
{
    public class FuncionarioBuilder
    {
        private string _nome = "uisdafsdaf";
        private string _email = "uisdafsdaf";
        private int _filialId = 1;
        private string _senha = "uisdafsdaf";

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
            _filialId = filialId;
            return this;
        }

        public FuncionarioBuilder ComSenha(string senha)
        {
            _senha = senha;
            return this;
        }

        public Funcionario Build()
        {
            return new Funcionario(_nome,_email,_filialId,_senha);
        }

    }

}