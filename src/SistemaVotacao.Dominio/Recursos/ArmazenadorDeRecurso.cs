using System;

namespace SistemaVotacao.Dominio.Recursos
{
     public class ArmazenadorDeRecurso
    {
        private IRecursoRepositorio _repositorio;

        public ArmazenadorDeRecurso(IRecursoRepositorio recursoRepositorio)
        {
            _repositorio = recursoRepositorio;
            
        }
        public void Armazenar(RecursoDto recursoDto)
        {            
            var novoRecurso = new Recurso(recursoDto.Nome, recursoDto.Descricao);
             _repositorio.Adicionar(novoRecurso);
        }
    }

    
}