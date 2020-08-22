using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SistemaVotacao.Dominio._Base;
using SistemaVotacao.Dominio.Votos;

namespace SistemaVotacao.Dominio.Funcionarios
{
    public class Funcionario : Entidade
    {
        private readonly Regex _emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public virtual ICollection<Voto> Votos { get; set; }

        public Funcionario(string nome, string email, string senha)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (string.IsNullOrEmpty(senha))
                throw new ArgumentException("Senha não pode ser vazia ou nula");

            if (string.IsNullOrEmpty(email) || !_emailRegex.Match(email).Success)
                throw new ArgumentException("Email inválido");

            Votos = new HashSet<Voto>();

            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
        }
    }

}