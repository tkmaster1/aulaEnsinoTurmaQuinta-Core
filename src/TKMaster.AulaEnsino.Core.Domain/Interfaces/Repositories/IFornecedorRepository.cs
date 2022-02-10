using System.Collections.Generic;
using System.Threading.Tasks;
using TKMaster.AulaEnsino.Core.Domain.Entities;

namespace TKMaster.AulaEnsino.Core.Domain.Interfaces.Repositories
{
    public interface IFornecedorRepository : IRepositoryBase<Fornecedor>
    {
        Task<IEnumerable<Fornecedor>> ListarTodosAtivo();

        Task<Fornecedor> NomeExiste(string nome);

        Task<Fornecedor> DocumentoExiste(string documento);
    }
}
