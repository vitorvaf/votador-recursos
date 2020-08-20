using System;
using SistemaVotacao.Dominio._Base;
using SistemaVotacao.Dominio.Recursos;
using SistemaVotacao.Dominio.Funcionarios;

namespace SistemaVotacao.Dominio.Votos
{
    public class Voto : Entidade
    {
        public string Comentario { get; private set; }
        public DateTime DataVoto { get; private  set; }
        public Recurso Recurso { get; private  set; }
        public int IdRecurso { get; private  set; }
        public virtual Funcionario IdFuncionarioNavigation { get; set; }
        public virtual Recurso IdRecursoNavigation { get; set; }
        public Funcionario Funcionario { get; private set; }
        public int IdFuncionario { get; private set; }

        public Voto(string comentario, DateTime dataVoto, int idRecurso, int idFuncionario)
        {
            if(string.IsNullOrEmpty(comentario))
                throw new ArgumentException("Comentario inválido");
            
            if(dataVoto == null || dataVoto.AddMilliseconds(500) < DateTime.Now)
                throw new ArgumentException("Data inválida");

            if(idRecurso <= 0)
                throw new ArgumentException("Id do recurso inválido");

            if(idFuncionario <= 0)
                throw new ArgumentException("Id do funcionário inválido");
            Comentario = comentario;
            DataVoto = dataVoto;
            IdRecurso = idRecurso;
            IdFuncionario = idFuncionario;            
        }
        
        
    }
    
}