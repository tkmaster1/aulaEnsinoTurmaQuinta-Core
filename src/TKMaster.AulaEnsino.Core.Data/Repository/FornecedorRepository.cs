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

        #endregion
    }
}
