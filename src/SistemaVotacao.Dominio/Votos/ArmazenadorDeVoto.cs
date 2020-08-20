using System;

namespace SistemaVotacao.Dominio.Votos
{
    public class ArmazenadorDeVotos
    {
        private IVotoRepositorio _repositorio;

        public ArmazenadorDeVotos(IVotoRepositorio repositorio)
        {
            _repositorio = repositorio;            
        }

        public void Armazenar(VotoDTO votoDTO)
        {
            var votoComputado = _repositorio.BuscarVotoPeloIdFuncionario(votoDTO.IdFuncionario);
            if(votoComputado != null)
                throw new ArgumentException("É permitido votar apenas uma vez");
            var voto = new Voto(
                votoDTO.Comentario,
                votoDTO.DataVoto,
                votoDTO.IdRecurso,
                votoDTO.IdFuncionario);

            _repositorio.Adicionar(voto);
        }
        
    }

    
}