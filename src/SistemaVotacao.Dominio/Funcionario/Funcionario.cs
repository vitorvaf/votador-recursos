using System;
using System.Text.RegularExpressions;

namespace SistemaVotacao.Dominio.Funcionario
{
     public class Funcionario
    {
        private readonly Regex _emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public Funcionario(string nome, string email, string senha)
        {           
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (string.IsNullOrEmpty(senha))
                throw new ArgumentException("Senha não pode ser vazia ou nula");

            if(string.IsNullOrEmpty(email) || !_emailRegex.Match(email).Success)
                throw new ArgumentException("Email inválido");

            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
        }
    }
    
}