using System;
using System.Data.Entity;

namespace Persistencia
{
    public class UnitOfWork<T>  where T : class
    {
        private DbContext _contexto;
        private Repository<T> _repository;

        public UnitOfWork(DbContext contexto)
        {
            _contexto = contexto;
        }

        public Repository<T> Repository
        {
            get
            {
                if (this._repository == null)
                {
                    this._repository = new Repository<T>(_contexto);
                }

                return _repository;
            }
        }

        public void Save()
        {
            _contexto.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}