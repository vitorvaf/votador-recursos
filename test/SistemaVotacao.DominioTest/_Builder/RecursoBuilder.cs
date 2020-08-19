using System;
using SistemaVotacao.Dominio.Recursos;

namespace SistemaVotacao.DominioTest._Builder
{
    public class RecursoBuilder
    {
        private string _nome = "Sistema de votação de recursos";
        private string _descricao = "Novo recurso sugerido pela filial matriz";

        public static RecursoBuilder Novo()
        {
            return new RecursoBuilder();

        }

        public RecursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public RecursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public Recurso Build()
        {
            return new Recurso (_nome, _descricao);
        }
        
    }
    
}