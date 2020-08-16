using System;

namespace SistemaVotacao.Dominio.Filiais
{
    public class ArmazenadorDeFilial
    {
        private readonly IFilialRepositorio _filialRepositorio;

        public ArmazenadorDeFilial(IFilialRepositorio filialRepositorio)
        {
            _filialRepositorio = filialRepositorio;
        }

        public void Armazenar(FilialDto filialDto)
        {
            var filial = _filialRepositorio.BuscarPorNome(filialDto.nome);

            if (filial != null)
                throw new ArgumentException("Filial já salva na base de dados");

            var novaFilial = new Filial(filialDto.nome,
                filialDto.rua, filialDto.uf,
                filialDto.cidade,
                filialDto.bairro,
                filialDto.numero,
                filialDto.complemento);

            _filialRepositorio.Adicionar(novaFilial);
        }
    }

}