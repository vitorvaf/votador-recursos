using System;
using Xunit;
using Moq;
using SistemaVotacao.Dominio.Filiais;
using Bogus;
using SistemaVotacao.DominioTest._Builder;
using SistemaVotacao.DominioTest._Util;

namespace SistemaVotacao.DominioTest.Filiais
{

    public class ArmazenadorDeFiliaisTest
    {
        private FilialDto _filialDto;
        private readonly Mock<IFilialRepositorio> _filialRepositorioMock;
        private readonly ArmazenadorDeFilial _armazenadorDeFilial;

        public ArmazenadorDeFiliaisTest()
        {
            var fake = new Faker();

            _filialDto = new FilialDto
            {
                nome = fake.Random.Words(),
                rua = fake.Address.StreetName(),
                uf = fake.Address.StreetSuffix(),
                cidade = fake.Address.City(),
                bairro = fake.Address.City(),
                numero = fake.Address.BuildingNumber(),
                complemento = ""
            };
            _filialRepositorioMock = new Mock<IFilialRepositorio>();
            _armazenadorDeFilial = new ArmazenadorDeFilial(_filialRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarFilial()
        {
            _armazenadorDeFilial.Armazenar(_filialDto);

            _filialRepositorioMock.Verify(repository => repository.Adicionar(
                It.Is<Filial>(
                    f => f.Nome == _filialDto.nome &&
                    f.Rua == _filialDto.rua &&
                    f.Uf == _filialDto.uf &&
                    f.Cidade == _filialDto.cidade &&
                    f.Bairro == _filialDto.bairro &&
                    f.Numero == _filialDto.numero &&
                    f.Complemento == _filialDto.complemento
            )));
        }


        [Fact]
        public void NaoDeveAdicionarFilialIgualAOutraJaSalva()
        {
            var filialJaSalva = FilialBuilder.Novo().ComNome(_filialDto.nome).Build();
            _filialRepositorioMock.Setup(r => r.BuscarPorNome(_filialDto.nome)).Returns(filialJaSalva);

            Assert.Throws<ArgumentException>(() => _armazenadorDeFilial.Armazenar(_filialDto))
                .ComMensagem("Filial já salva na base de dados");
        }

    }

}


