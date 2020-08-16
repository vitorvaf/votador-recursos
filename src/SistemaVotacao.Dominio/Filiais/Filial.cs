using System;

namespace SistemaVotacao.Dominio.Filiais
{
    public class Filial
    {
        public string Nome { get; private set; }
        public string Rua { get; private set; }
        public string Uf { get; private set; }
        public string Cidade { get; private set; }

        public string Bairro { get; private set; }

        public string Numero { get; private set; }
        public string Complemento { get; private set; }

        public Filial(string nome, string rua, string uf, string cidade, string bairro, string numero, string complemento)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (string.IsNullOrEmpty(uf))
                throw new ArgumentException("Uf inválido");

            if (string.IsNullOrEmpty(rua))
                throw new ArgumentException("Rua inválida");

            if (string.IsNullOrEmpty(cidade))
                throw new ArgumentException("Cidade inválida");

            if (string.IsNullOrEmpty(bairro))
                throw new ArgumentException("Bairro inválido");


            this.Nome = nome;
            this.Rua = rua;
            this.Uf = uf;
            this.Cidade = cidade;
            this.Bairro = bairro;
            this.Numero = numero;
            this.Complemento = complemento;
        }
    }

}
