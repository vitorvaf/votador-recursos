using System;
using Bogus;
using Moq;
using SistemaVotacao.Dominio.Recursos;
using Xunit;

namespace SistemaVotacao.DominioTest.Recursos
{
    public class ArmazenadorDeRecursoTest
    {
        private RecursoDto _recursoDto;
        private Mock<IRecursoRepositorio> _recursoRepositorioMock;
        private ArmazenadorDeRecurso _armazenadorRecurso;

        public ArmazenadorDeRecursoTest()
        {
            var faker = new Faker();

            _recursoDto = new RecursoDto
            {
                Nome = faker.Random.Words(),
                Descricao = faker.Random.Words()                
            };

            _recursoRepositorioMock = new Mock<IRecursoRepositorio>();
            _armazenadorRecurso = new ArmazenadorDeRecurso(_recursoRepositorioMock.Object);
            
        }

        
        [Fact]
        public void DeveCriarRecurso()
        {
            _armazenadorRecurso.Armazenar(_recursoDto);

            _recursoRepositorioMock.Verify(repositorio => repositorio.ArmazenarRecurso(
                It.Is<Recurso>(r=> r.Nome == _recursoDto.Nome)
            ));
        }
        

    }
   
    
}