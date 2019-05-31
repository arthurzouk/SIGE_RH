﻿using RH_Banco.Context;
using RH_Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RH_Banco.Repository
{
    public abstract class Repository<TEntity> where TEntity : Entity, new()
    {
        protected RecursosHumanosContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(RecursosHumanosContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual void Remover(string id)
        {
            var entity = new TEntity { Id = id };
            DbSet.Remove(entity);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual TEntity ObterPorId(string id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> ObterTodosPaginado(int s, int t)
        {
            return DbSet.Take(t).Skip(s);
        }

        public IEnumerable<TEntity> ObterOnde(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public TEntity ObterPrimeiroOuPadrao(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public TEntity ObterUltimoOuPadrao(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.LastOrDefault(predicate);
        }

        public bool TemAlgum(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
