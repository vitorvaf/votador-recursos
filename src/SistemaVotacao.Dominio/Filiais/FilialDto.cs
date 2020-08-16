using System;

namespace SistemaVotacao.Dominio.Filiais
{
    public class FilialDto
    {
        public string nome { get; set; }
        public string rua { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
    }

}