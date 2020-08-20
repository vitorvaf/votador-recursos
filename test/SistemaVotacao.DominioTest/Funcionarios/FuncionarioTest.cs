using System;
using Bogus;
using ExpectedObjects;
using SistemaVotacao.Dominio.Funcionarios;
using SistemaVotacao.DominioTest._Builder;
using SistemaVotacao.DominioTest._Util;
using Xunit;



namespace SistemaVotacao.DominioTest.Funcionarios
{
    public class FuncionarioTest
    {

        private string _nome;
        private string _email;        
        private string _senha;

        public FuncionarioTest()
        {
            Faker faker = new Faker();
            _nome = faker.Person.FullName;
            _email = faker.Person.Email;            
            _senha = faker.Random.Word();
        }

        [Fact]
        public void DeveCriarFuncinario()
        {
            var funcionarioEsperado = new
            {
                Nome = "João José",
                Email = "joaojose@email.com",                
                Senha = "123123"
            };

            var funcionario = new Funcionario(
                funcionarioEsperado.Nome,
                funcionarioEsperado.Email,                
                funcionarioEsperado.Senha
            );

            funcionarioEsperado.ToExpectedObject().ShouldMatch(funcionario);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("email invalido")]
        [InlineData("email@invalido")]
        public void NaoDeveCriarFuncionarioComEmailInvalido(string emailInvalido)
        {
            Assert.Throws<ArgumentException>(() => FuncionarioBuilder.Novo()
            .ComEmail(emailInvalido)
            .Build()).ComMensagem("Email inválido");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarFuncionarioComNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() => FuncionarioBuilder.Novo()
            .ComNome(nomeInvalido)
            .Build()).ComMensagem("Nome inválido");

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarFuncionarioComSenhaInvalida(string senhaInvalida)
        {
            Assert.Throws<ArgumentException>(() => FuncionarioBuilder.Novo()
            .ComSenha(senhaInvalida)
            .Build()).ComMensagem("Senha não pode ser vazia ou nula");

        }


        public void NaoDeveCriarFuncionarioSemVinculoAFilial(int filialIdInvalida)
        {
            Assert.Throws<ArgumentException>(() => FuncionarioBuilder.Novo()
            .ComFilialId(filialIdInvalida)
            .Build()).ComMensagem("Funcionario deve ser vinculado a filial");

        }
    }

}