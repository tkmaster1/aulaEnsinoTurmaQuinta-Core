﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TKMaster.AulaEnsino.Core.Data.Context;
using TKMaster.AulaEnsino.Core.Domain;
using TKMaster.AulaEnsino.Core.Domain.Interfaces.Repositories;

namespace TKMaster.AulaEnsino.Core.Data.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : Entity, new()
    {
        #region Properties

        protected readonly MeuContexto Db;
        protected readonly DbSet<TEntity> DbSet;

        #endregion

        #region Constructor

        public RepositoryBase(MeuContexto meuContexto)
        {
            Db = meuContexto;
            DbSet = Db.Set<TEntity>();
        }

        #endregion

        #region Methods

        public virtual void Adicionar(TEntity entity)
        {
            entity.DataCadastro = DateTime.Now;
            entity.Status = true;
            DbSet.Add(entity);
        }

        public virtual void Adicionar(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities.ToArray());
        }

        public virtual void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Atualizar(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities.ToList());
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorCodigo(int codigo)
        {
            return await DbSet.FindAsync(codigo);
        }

        public virtual async Task<IEnumerable<TEntity>> ObterPorCodigos(IEnumerable<int> codigos)
        {
            return await DbSet.Where(x => codigos.Contains(x.Codigo)).ToListAsync();
        }

        public virtual async Task<bool> Existe(int codigo)
        {
            return await ObterPorCodigo(codigo) != null;
        }

        public virtual async Task<IEnumerable<TEntity>> ListarTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> ObterPorNome(string nome)
        {
            return await DbSet.FindAsync(nome);
        }

        public virtual void Remover(int codigo)
        {
            var entity = DbSet.Find(codigo);

            if (entity != null)
                DbSet.Remove(entity);
        }

        public virtual void Remover(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<int> Salvar()
        {
            return await Db.SaveChangesAsync();
        }

        public IQueryable<TEntity> Get()
        {
            return DbSet;
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        #endregion
    }
}
