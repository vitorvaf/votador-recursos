using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVotacao.Dominio.Votos;

namespace SistemaVotacao.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotoController : Controller
    {
        private ArmazenadorDeVotos _armazenadorVoto;
        private IVotoRepositorio _repositorio;

        public VotoController(ArmazenadorDeVotos armazenadorDeVotos, IVotoRepositorio repositorio)
        {
            _armazenadorVoto = armazenadorDeVotos;
            _repositorio = repositorio;            
        }      


        [HttpGet]
        public IActionResult Get()
        {
            var votos = _repositorio.Consultar();
            if(votos.Any())
            {
                var dtos = votos.Select( voto => new VotoDTO
                {
                    Id = voto.Id,
                    Comentario = voto.Comentario,
                    IdFuncionario = voto.IdFuncionario,
                    IdRecurso = voto.IdRecurso,
                    DataVoto = voto.DataVoto
                });
                
                return Ok(dtos);
            }

            return Ok(null);
        }


        [HttpPost]
        public IActionResult Post(VotoDTO voto)
        {
            _armazenadorVoto.Armazenar(voto);
            return Ok();
            
        }

    }

}
