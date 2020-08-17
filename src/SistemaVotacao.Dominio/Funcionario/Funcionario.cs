using System;

namespace SistemaVotacao.Dominio.Funcionario
{
     public class Funcionario
    {

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public int FilialId { get; private set; }
        public string Senha { get; private set; }

        public Funcionario(string nome, string email, int filialId, string senha)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email inválido");

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (string.IsNullOrEmpty(senha))
                throw new ArgumentException("Senha não pode ser vazia ou nula");

            if (filialId == null || filialId <= 0)
                throw new ArgumentException("Funcionario deve ser vinculado a filial");

            this.Nome = nome;
            this.Email = email;
            this.FilialId = filialId;
            this.Senha = senha;
        }
    }
    
}