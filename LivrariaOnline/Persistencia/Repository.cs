using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Persistencia
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _contexto;

        public Repository(DbContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(params T[] modelos)
        {
            foreach (T modelo in modelos)
            {
                _contexto.Entry(modelo).State = EntityState.Added;
            }
        }

        public void Alterar(params T[] modelos)
        {
            foreach (T modelo in modelos)
            {
                _contexto.Entry(modelo).State = EntityState.Modified;
            }
        }

        public void Remover(params T[] modelos)
        {
            foreach (T modelo in modelos)
            {
                _contexto.Entry(modelo).State = EntityState.Deleted;
            }
        }

        public List<T> ListaDeModelo(params Expression<Func<T, object>>[] modelos)
        {
            IQueryable<T> filtro = _contexto.Set<T>();
            foreach (Expression<Func<T, object>> modelo in modelos)
            {
                filtro = filtro.Include<T, object>(modelo);
            }
            return filtro.AsNoTracking().ToList();
        }

        public List<T> ListaDeModeloPersonalizado(Func<T, bool> logica, params Expression<Func<T, object>>[] modelos)
        {
            IQueryable<T> filtro = _contexto.Set<T>();
            foreach (Expression<Func<T, object>> modelo in modelos)
            {
                filtro = filtro.Include<T, object>(modelo);
            }
            return filtro.AsNoTracking().Where(logica).ToList();
        }        

        public T RetornaModelo(Func<T, bool> logica, params Expression<Func<T, object>>[] modelos)
        {
            IQueryable<T> filtro = _contexto.Set<T>();
            foreach (Expression<Func<T, object>> modelo in modelos)
            {
                filtro = filtro.Include<T, object>(modelo);
            }
            return filtro.AsNoTracking().FirstOrDefault(logica);
        }
    }
}