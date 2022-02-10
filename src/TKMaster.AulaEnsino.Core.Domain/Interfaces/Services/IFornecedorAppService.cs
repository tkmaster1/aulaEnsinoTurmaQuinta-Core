using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TKMaster.AulaEnsino.Core.Domain.Entities;

namespace TKMaster.AulaEnsino.Core.Domain.Interfaces.Services
{
    public interface IFornecedorAppService : IDisposable
    {
        Task<IEnumerable<Fornecedor>> ListarTodosAtivo();

        Task<IEnumerable<Fornecedor>> ListarTodos();

        Task<Fornecedor> ObterPorCodigo(int codigo);

        Task<int> Adicionar(Fornecedor entity);

        Task<bool> Atualizar(Fornecedor entity);

        Task<bool> Excluir(Fornecedor entity);

        Task<bool> Reativar(Fornecedor entity);

        Task<Fornecedor> NomeExiste(string nome);

        Task<Fornecedor> DocumentoExiste(string documento);
    }
}
