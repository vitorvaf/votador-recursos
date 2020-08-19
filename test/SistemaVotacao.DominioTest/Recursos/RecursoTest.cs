using System;
using Xunit;
using Bogus;
using SistemaVotacao.Dominio.Recursos;
using SistemaVotacao.DominioTest._Builder;
using ExpectedObjects;
using SistemaVotacao.DominioTest._Util;

namespace SistemaVotacao.DominioTest.Recursos
{
    public class RecursoTest
    {
        private string _nome;
        private string _descricao;

        public RecursoTest()
        {
            var faker = new Faker();
            _nome = faker.Random.Words();
            _descricao = faker.Random.Words();
        }

        [Fact]
        public void DeveCriarRecurso()
        {            
            var recursoEsperado = new
            {
                Nome = _nome,
                Descricao = _descricao
            };

            var recurso = new Recurso(recursoEsperado.Nome, recursoEsperado.Descricao);
            recursoEsperado.ToExpectedObject().ShouldMatch(recurso);

        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarRecursoComNomeInvalido(string nomeInvalido)
        {
             Assert.Throws<ArgumentException>(()=> 
                RecursoBuilder.Novo().ComNome(nomeInvalido).Build()).ComMensagem("Nome inválido");
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarRecursoComDescricaoInvalida(string descricaoInvalida)
        {
             Assert.Throws<ArgumentException>(()=> 
                RecursoBuilder.Novo().ComDescricao(descricaoInvalida).Build()).ComMensagem("Descricao inválida");
        }

        
    }


    
}