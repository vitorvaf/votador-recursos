using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVotacao.Dominio.Funcionarios;

namespace SistemaVotacao.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        private ArmazenadorDeFuncionario _armazenadorFuncionario;
        private IFuncionarioRepositorio _repositorio;

        public FuncionarioController(ArmazenadorDeFuncionario armazenadorFuncionario,
            IFuncionarioRepositorio repositorio)
        {
            _armazenadorFuncionario = armazenadorFuncionario;
            _repositorio = repositorio;
        }


        [HttpPost]
        public IActionResult Post(FuncionarioDTO funcionarioDto)
        {
            _armazenadorFuncionario.Adicionar(funcionarioDto);
            return Ok();
        }

    }

}
