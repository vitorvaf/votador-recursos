using System;

namespace SistemaVotacao.Dominio.Recursos
{
    public interface IRecursoRepositorio
    {
        void ArmazenarRecurso(Recurso recurso);
        void AlterarRecurso(Recurso recurso);
    }

    
}