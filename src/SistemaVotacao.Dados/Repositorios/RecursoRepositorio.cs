using SistemaVotacao.Dados.Contextos;
using SistemaVotacao.Dados.Repositorios;
using SistemaVotacao.Dominio.Recursos;

namespace SistemaVotacao.Dados.Repositorios
{
    public class RecursoRepositorio : RepositorioBase<Recurso>, IRecursoRepositorio
    {
        public RecursoRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public void AlterarRecurso(Recurso recurso)
        {
            Context.Update(recurso);
            Context.Entry(recurso);
        }

     
    }

}