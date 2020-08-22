using System.Threading.Tasks;

namespace SistemaVotacao.Dominio._Base
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
