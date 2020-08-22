using System;

namespace SistemaVotacao.Dominio.Funcionarios
{
    public class ArmazenadorDeFuncionario
    {

        private IFuncionarioRepositorio _funcionarioRepositorio;

        public ArmazenadorDeFuncionario(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            
        }

        public void Adicionar(FuncionarioDTO funcionarioDto)
        {
            var funcionarioExiste = _funcionarioRepositorio.ObterPeloEmail(funcionarioDto.Email);

            if(funcionarioExiste != null)
                throw new ArgumentException("Email ja cadastrado");

            var novoFuncionario = new Funcionario(funcionarioDto.Nome,funcionarioDto.Email, funcionarioDto.Senha);
            _funcionarioRepositorio.Adicionar(novoFuncionario);
            
        }

        public Funcionario ObterPeloEmail(string email)
        {
            var funcionario = _funcionarioRepositorio.ObterPeloEmail(email);
            return funcionario;

        }
    }
    
}