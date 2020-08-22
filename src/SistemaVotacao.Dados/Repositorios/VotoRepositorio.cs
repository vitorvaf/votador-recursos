using System;
using System.Collections.Generic;
using System.Linq;
using SistemaVotacao.Dados.Contextos;
using SistemaVotacao.Dominio.Votos;

namespace SistemaVotacao.Dados.Repositorios
{
    public class VotoRepositorio : RepositorioBase<Voto>, IVotoRepositorio
    {
        public VotoRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public Voto BuscarVotoPeloIdFuncionario(int idFuncionario)
        {            
            var entidade = Context.Set<Voto>()
                .Where(x => x.IdFuncionarioNavigation.Id == idFuncionario)
                .FirstOrDefault();
                
            if (entidade != null)
                return entidade;
            return null;
        }
    }

}