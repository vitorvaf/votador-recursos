using System;
using SistemaVotacao.Dominio._Base;

namespace SistemaVotacao.Dominio.Recursos
{
    public interface IRecursoRepositorio : IRepositorio<Recurso>
    {        
        void AlterarRecurso(Recurso recurso);
    }

    
}