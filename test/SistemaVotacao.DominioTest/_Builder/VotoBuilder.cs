using System;
using SistemaVotacao.Dominio.Votos;

namespace SistemaVotacao.DominioTest._Builder
{

    public class VotoBuilder
    {
        private string _comentario = "Comentario relacionado ao voto";
        private DateTime _dataVoto = DateTime.Now.ToLocalTime();
        private int _idRecurso = 1;
        private int _idFuncionario = 1;

        public static VotoBuilder Novo()
        {
            return new VotoBuilder();
        }

        public VotoBuilder ComComentario(string comentario)
        {
            _comentario = comentario;
            return this;
        }

        public VotoBuilder ComDataVoto(DateTime dataVoto)
        {
            _dataVoto = dataVoto;
            return this;
        }

        public VotoBuilder ComIdRecurso(int idRecurso)
        {
            _idRecurso = idRecurso;
            return this;
        }

        public VotoBuilder ComIdFuncionario(int idFuncionario)
        {
            _idFuncionario = idFuncionario;
            return this;
        }

        public Voto Build()
        {
            return new Voto(_comentario,_dataVoto,_idRecurso, _idFuncionario);
        }
        
    }
    
}