using System;

namespace SistemaVotacao.Dominio
{
    public class Filial
    {
        public string nome { get; private set; }
        public string rua { get; private set; }
        public string uf { get; private set; }
        public string cidade { get; private set; }

        public string bairro { get; private set; }

        public string numero { get; private set; }
        public string complemento { get; private set; }

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


            this.nome = nome;
            this.rua = rua;
            this.uf = uf;
            this.cidade = cidade;
            this.bairro = bairro;
            this.numero = numero;
            this.complemento = complemento;
        }
    }

}
