using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKMaster.AulaEnsino.Core.Data.Context;
using TKMaster.AulaEnsino.Core.Domain.Entities;
using TKMaster.AulaEnsino.Core.Domain.Interfaces.Repositories;

namespace TKMaster.AulaEnsino.Core.Data.Repository
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        #region Constructor

        public FornecedorRepository(MeuContexto contexto) : base(contexto) { }

        #endregion

        #region Methods

        public async Task<IEnumerable<Fornecedor>> ListarTodosAtivo()
        {
            return await DbSet.Where(x => x.Status).ToListAsync();
        }

        public async Task<Fornecedor> DocumentoExiste(string documento)
        {
            return await DbSet.Where(x => x.Documento.Trim().Equals(documento.Trim())).FirstOrDefaultAsync();
        }

        public async Task<Fornecedor> NomeExiste(string nome)
        {
            return await DbSet.Where(x => x.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper())).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Fornecedor>> BuscarFornecedores(Fornecedor fornecedor)
        {
            var query = Db.Fornecedores.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(fornecedor.Nome))
            {
                query = query.Where(x => x.Nome.Trim().ToUpper().Contains(fornecedor.Nome.Trim().ToUpper()));
            }

            if (!string.IsNullOrEmpty(fornecedor.Documento))
            {
                query = query.Where(x => x.Documento.Trim().Equals(fornecedor.Documento.Trim()));
            }

            if (!string.IsNullOrEmpty(fornecedor.TipoPessoa))
            {
                query = query.Where(x => x.TipoPessoa.Trim().ToUpper().Equals(fornecedor.TipoPessoa.Trim().ToUpper()));
            }

            if (!string.IsNullOrEmpty(fornecedor.StatusPesquisa))
            {
                var bStatus = Convert.ToInt32(fornecedor.StatusPesquisa) == 0 ? false : true;
                query = query.Where(x => x.Status == bStatus);
            }

            var retorno = await query.OrderBy(x => x.Nome).ToListAsync();
            return retorno;
        }

        #endregion
    }
}
