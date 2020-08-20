using System;
using Bogus;
using Moq;
using SistemaVotacao.Dominio.Votos;
using SistemaVotacao.DominioTest._Builder;
using SistemaVotacao.DominioTest._Util;
using Xunit;

namespace SistemaVotacao.DominioTest.Votos
{
    public class ArmazenadorDeVotosTest
    {
        private VotoDTO _votoDto;
        private Mock<IVotoRepositorio> _votoRepositorioMock;
        private ArmazenadorDeVotos _armazenadorVoto;

        public ArmazenadorDeVotosTest()
        {

            var faker = new Faker();
            _votoDto = new VotoDTO
            {
                Comentario = faker.Lorem.Paragraph(),
                DataVoto = DateTime.Now,
                IdRecurso = 1,
                IdFuncionario = 1
            };

            _votoRepositorioMock = new Mock<IVotoRepositorio>();
            _armazenadorVoto = new ArmazenadorDeVotos(_votoRepositorioMock.Object);

        }

        [Fact]
        public void DeverArmazenarFilial()
        {            
            _armazenadorVoto.Armazenar(_votoDto);

            _votoRepositorioMock.Verify(repositorio => repositorio.Adicionar(
                It.Is<Voto>(voto=> voto.Comentario == _votoDto.Comentario
                && voto.IdFuncionario == _votoDto.IdFuncionario
                && voto.IdRecurso == _votoDto.IdRecurso)
            ));
        }

        [Fact]
        public void NaoDeveArmazenarVotoQuandoFuncionarioJaVotou()
        {
            var votoComputado = VotoBuilder.Novo().ComIdFuncionario(35).Build();
            _votoRepositorioMock.Setup(voto => voto.BuscarVotoPeloIdFuncionario(_votoDto.IdFuncionario))
                                .Returns(votoComputado);

            Assert.Throws<ArgumentException>(() => _armazenadorVoto.Armazenar(_votoDto))
                .ComMensagem("É permitido votar apenas uma vez");

        }
    }

}