using System;

namespace SistemaVotacao.Dominio.Recursos
{
    public class Recurso
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public Recurso(string nome, string descricao)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentException("Descricao inválida");



            this.Nome = nome;
            this.Descricao = descricao;
        }

    }

}