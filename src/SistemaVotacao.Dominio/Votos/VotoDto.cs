using System;

namespace SistemaVotacao.Dominio.Votos
{
    public class VotoDTO
    {
        public string Comentario { get; set; }
        public DateTime DataVoto { get; set; }
        public int IdRecurso { get; set; }
        public int IdFuncionario { get; set; }
    }

}