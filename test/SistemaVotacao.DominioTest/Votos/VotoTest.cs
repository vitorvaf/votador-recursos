using System;
using Xunit;
using SistemaVotacao.Dominio.Recursos;
using Bogus;
using SistemaVotacao.Dominio.Votos;
using ExpectedObjects;
using SistemaVotacao.DominioTest._Builder;
using SistemaVotacao.DominioTest._Util;

namespace SistemaVotacao.DominioTest.Votos
{
    public class VotoTest
    {
        private Faker _faker;
        private string _comentario;
        private DateTime _dataVoto;
        private int _idRecurso;
        private int _idFuncionario;

        public VotoTest()
        {
            _faker = new Faker();
            _comentario = _faker.Lorem.Text();
            _dataVoto = DateTime.Now;
            _idRecurso = 1;
            _idFuncionario = 1;

        }

        [Fact]
        public void DeveCriarVoto()
        {
            var votoEsperado = new
            {
                Comentario = _comentario,
                DataVoto = _dataVoto,
                IdRecurso = _idRecurso,
                IdFuncionario = _idFuncionario
            };

            var voto = new Voto(
                votoEsperado.Comentario,
                votoEsperado.DataVoto,
                votoEsperado.IdRecurso,
                votoEsperado.IdFuncionario
            );

            votoEsperado.ToExpectedObject().ShouldMatch(voto);


        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarVotoSemComentario(string comentarioInvalido)
        {
            Assert.Throws<ArgumentException>(() => VotoBuilder.Novo()
            .ComComentario(comentarioInvalido)
            .Build()).ComMensagem("Comentario inválido");
        }

        [Fact]
        public void NaoDeveCriarVotoComDataInvalida()
        {
            var dataInvalida = _faker.Date.Past();

            Assert.Throws<ArgumentException>(() => VotoBuilder.Novo()
            .ComDataVoto(dataInvalida)
            .Build()).ComMensagem("Data inválida");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(-2)]
        [InlineData(-1)]
        [InlineData(0)]
        public void NaoDeveCriarVotoSemIdRecurso(int idRecursoInvalido)
        {
            Assert.Throws<ArgumentException>(() => VotoBuilder.Novo()
            .ComIdRecurso(idRecursoInvalido)
            .Build())
            .ComMensagem("Id do recurso inválido");

        }
        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-150)]
        public void NaoDeveCriarVotoSemIdDoFuncionario(int idFuncionarioInvalido)
        {
            Assert.Throws<ArgumentException>(() => VotoBuilder.Novo()
            .ComIdFuncionario(idFuncionarioInvalido)
            .Build()).ComMensagem("Id do funcionário inválido");
        }



    }

}