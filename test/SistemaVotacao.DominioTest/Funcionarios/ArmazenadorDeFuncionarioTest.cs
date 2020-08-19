using System;
using Bogus;
using Moq;
using SistemaVotacao.Dominio.Funcionario;
using SistemaVotacao.DominioTest._Builder;
using SistemaVotacao.DominioTest._Util;
using Xunit;

namespace SistemaVotacao.DominioTest.Funcionarios
{
    public class ArmazenadorDeFuncionarioTest
    {
        private readonly Faker _faker;
        private readonly FuncionarioDTO _funcionarioDto;
        private readonly ArmazenadorDeFuncionario _armazenadorDeFuncionario;
        private readonly Mock<IFuncionarioRepositorio> _funcionarioRepositorio;

        public ArmazenadorDeFuncionarioTest()
        {
            _faker = new Faker();
            _funcionarioDto = new FuncionarioDTO
            {
                Nome =_faker.Person.FullName,
                Email = _faker.Person.Email,
                Senha = _faker.Random.Words()
            };

            _funcionarioRepositorio = new Mock<IFuncionarioRepositorio>();            
            _armazenadorDeFuncionario = new ArmazenadorDeFuncionario(_funcionarioRepositorio.Object);

        }


        [Fact]
        public void DeveAdicionarFuncionario()
        {
            _armazenadorDeFuncionario .Adicionar(_funcionarioDto);
            _funcionarioRepositorio.Verify( r => r.Adicionar(It.Is<Funcionario>(f => f.Email == _funcionarioDto.Email)));            
        }

        [Fact]
        public void NaoDeveAdicionarFuncionarioComEmailJaCadastrado()
        {
            var funcionarioComEmailCadastrado = FuncionarioBuilder.Novo()
                .ComEmail(_funcionarioDto.Email)
                .Build();

            _funcionarioRepositorio.Setup(x => x.ObterPeloEmail(_funcionarioDto.Email))
                                   .Returns(funcionarioComEmailCadastrado);

            Assert.Throws<ArgumentException>(() => _armazenadorDeFuncionario.Adicionar(_funcionarioDto))
                .ComMensagem("Email ja cadastrado");            

        }

    }    

}