using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TKMaster.AulaEnsino.Core.Domain.Entities;
using TKMaster.AulaEnsino.Core.Domain.Interfaces.Repositories;
using TKMaster.AulaEnsino.Core.Domain.Interfaces.Services;

namespace TKMaster.AulaEnsino.Core.Service.Application
{
    public class FornecedorAppService : IFornecedorAppService
    {
        #region Properties

        private readonly IFornecedorRepository _fornecedorRepository;

        #endregion

        #region Constructor

        public FornecedorAppService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Fornecedor>> ListarTodos()
        {
            return await _fornecedorRepository.ListarTodos();
        }

        public async Task<IEnumerable<Fornecedor>> ListarTodosAtivo()
        {
            return await _fornecedorRepository.ListarTodosAtivo();
        }

        public async Task<ICollection<Fornecedor>> BuscarFornecedores(Fornecedor fornecedor)
        {
            return await _fornecedorRepository.BuscarFornecedores(fornecedor);
        }

        public async Task<int> Adicionar(Fornecedor entity)
        {
            _fornecedorRepository.Adicionar(entity);
            await _fornecedorRepository.Salvar();
            return entity.Codigo;
        }

        public async Task<bool> Atualizar(Fornecedor entity)
        {
            var model = await _fornecedorRepository.ObterPorCodigo(entity.Codigo);

            if (model != null)
            {
                model.Nome = entity.Nome;
                model.Documento = entity.Documento;
                model.TipoPessoa = entity.TipoPessoa;
                model.DataCadastro = DateTime.Now;
                model.Status = true;

                _fornecedorRepository.Atualizar(model);
            }

            return await _fornecedorRepository.Salvar() > 0;
        }

        public async Task<Fornecedor> NomeExiste(string nome)
        {
            return await _fornecedorRepository.NomeExiste(nome);
        }

        public async Task<Fornecedor> DocumentoExiste(string documento)
        {
            return await _fornecedorRepository.DocumentoExiste(documento);
        }

        public async Task<Fornecedor> ObterPorCodigo(int codigo)
        {
            return await _fornecedorRepository.ObterPorCodigo(codigo);
        }

        public async Task<bool> Excluir(Fornecedor entity)
        {
            var model = await _fornecedorRepository.ObterPorCodigo(entity.Codigo);

            if (model != null)
            {
                model.Status = false;
                model.DataExclusao = DateTime.Now;

                _fornecedorRepository.Atualizar(model);
            }

            return await _fornecedorRepository.Salvar() > 0;
        }

        public async Task<bool> Reativar(Fornecedor entity)
        {
            var model = await _fornecedorRepository.ObterPorCodigo(entity.Codigo);

            if (model != null)
            {
                model.Status = true;
                model.DataAlteracao = DateTime.Now;

                _fornecedorRepository.Atualizar(model);
            }

            return await _fornecedorRepository.Salvar() > 0;
        }       

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
