using System;
using Xunit;
using ExpectedObjects;
using Xunit.Abstractions;
using Bogus;
using SistemaVotacao.DominioTest._Util;
using SistemaVotacao.DominioTest._Builder;
using SistemaVotacao.Dominio.Filiais;



namespace SistemaVotacao.DominioTest.Filiais
{
    public class FilialTest
    {
        private ITestOutputHelper _output;
        private string _nome;
        private string _rua;
        private string _uf;
        private string _cidade;
        private string _bairro;
        private string _numero;
        private string _complemento;

        public FilialTest(ITestOutputHelper output)
        {
            _output = output;
            _nome = "Alterdata Matriz";
            _rua = "R. Pref. Sebastião Teixeira";
            _uf = "RJ";
            _cidade = "Teresopolis";
            _bairro = "Várzea";
            _numero = "227";
            _complemento = "";

            var Faker = new Faker();

        }



        [Fact(DisplayName = "DeveCriarFilial")]
        public void DeveCriarFilial()
        {

            var filialEsperada = new
            {
                Nome = _nome,
                Rua = _rua,
                UF = _uf,
                Cidade = _cidade,
                Bairro = _bairro,
                Numero = _numero,
                Complemento = _complemento
            };

            var filial = new Filial(
                filialEsperada.Nome,
                filialEsperada.Rua,
                filialEsperada.UF,
                filialEsperada.Cidade,
                filialEsperada.Bairro,
                filialEsperada.Numero,
                filialEsperada.Complemento);

            filialEsperada.ToExpectedObject().ShouldNotMatch(filial);


        }



        [Theory(DisplayName = "NaoDeveFilialTerNomeInvalido")]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveFilialTerNomeInvalido(string nomeInvalido)
        {

            Assert.Throws<ArgumentException>(() =>
            FilialBuilder.Novo().ComNome(nomeInvalido).Build()).ComMensagem("Nome inválido");


        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveFilialTerUFInvalida(string ufInvalida)
        {
            Assert.Throws<ArgumentException>(() =>
                FilialBuilder.Novo().ComUF(ufInvalida).Build()).ComMensagem("Uf inválido");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveFilialTerRuaInvalida(string ruaInvalida)
        {
            Assert.Throws<ArgumentException>(() =>
                FilialBuilder.Novo().ComRua(ruaInvalida).Build()).ComMensagem("Rua inválida");

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveFilialTerCidadeInvalida(string cidadeInvalida)
        {

            Assert.Throws<ArgumentException>(() =>
                FilialBuilder.Novo().ComCidade(cidadeInvalida).Build()).ComMensagem("Cidade inválida");

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveFilialTerBairroInvalido(string bairroInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                FilialBuilder.Novo().ComBairro(bairroInvalido).Build()).ComMensagem("Bairro inválido");
        }

    }


}