using System;
using SistemaVotacao.Dominio;
using static SistemaVotacao.DominioTest.Filiais.FilialTest;

namespace SistemaVotacao.DominioTest._Builder
{
    public class FilialBuilder
    {
        private string _nome = "Alterdata Matriz";
        private string _rua = "R. Pref. Sebastião Teixeira";
        private string _uf = "RJ";
        private string _cidade = "Teresopolis";
        private string _bairro = "Várzea";
        private string _numero = "227";
        private string _complemento = "";


        public static FilialBuilder Novo()
        {
            return new FilialBuilder();
        }

        public FilialBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public FilialBuilder ComRua(string rua)
        {
            _rua = rua;
            return this;
        }

        public FilialBuilder ComUF(string uf)
        {
            _uf = uf;
            return this;
        }

        public FilialBuilder ComCidade(string cidade)
        {
            _cidade = cidade;
            return this;
        }

        public FilialBuilder ComBairro(string bairro)
        {
            _bairro = bairro;
            return this;
        }

        public FilialBuilder ComNumero(string numero)
        {
            _numero = numero;
           return this; 
        }

        public FilialBuilder ComComplemento(string complemento)
        {
            _complemento = complemento;
            return this;
        }


        public Filial Build()
        {
            return new Filial(_nome, _rua, _uf, _cidade, _bairro, _numero, _complemento);
        }

    }

}