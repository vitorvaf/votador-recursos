using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVotacao.Dominio.Recursos;

namespace SistemaVotacao.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecursoController : Controller
    {
        private ArmazenadorDeRecurso _armazenadorDeRecurso;
        private IRecursoRepositorio _repositorio;

        public RecursoController(ArmazenadorDeRecurso armazenadorDeRecurso, IRecursoRepositorio repositorio)
        {
            _armazenadorDeRecurso = armazenadorDeRecurso;
            _repositorio = repositorio;
            
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            var recursos = _repositorio.Consultar();
            if(recursos.Any())
            {
                var dtos = recursos.Select( r => new RecursoDto
                {
                    Id = r.Id,
                    Nome = r.Nome,
                    Descricao = r.Descricao
                });

                return Ok(dtos);
            }

            return Ok(null);            
        }

        [HttpPost]
        public IActionResult Post(RecursoDto recursoDto)
        {
            _armazenadorDeRecurso.Armazenar(recursoDto);            
            return Ok();
        }

    }

}
