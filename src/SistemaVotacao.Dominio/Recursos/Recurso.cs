using System;
using System.Collections.Generic;
using SistemaVotacao.Dominio._Base;
using SistemaVotacao.Dominio.Votos;

namespace SistemaVotacao.Dominio.Recursos
{
    public class Recurso : Entidade
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public virtual ICollection<Voto> Votos { get; set; }

        public Recurso(string nome, string descricao)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentException("Descricao inválida");

            Votos = new HashSet<Voto>();

            this.Nome = nome;
            this.Descricao = descricao;
        }

    }

}