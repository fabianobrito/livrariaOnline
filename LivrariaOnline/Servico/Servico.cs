using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Servico
{
    public class Servico<T> : IServico<T> where T : class
    {
        private UnitOfWork<T> _unitOfWork;
        public Servico(UnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Adicionar(params T[] modelos)
        {
            _unitOfWork.Repository.Adicionar(modelos);
            _unitOfWork.Save();
        }

        public void Alterar(params T[] modelos)
        {
            _unitOfWork.Repository.Alterar(modelos);
            _unitOfWork.Save();
        }

        public void Remover(params T[] modelos)
        {
            _unitOfWork.Repository.Remover(modelos);
            _unitOfWork.Save();
        }

        public List<T> ListaDeModelo(params Expression<Func<T, object>>[] modelos)
        {
            return _unitOfWork.Repository.ListaDeModelo(modelos);
        }

        public List<T> ListaDeModeloPersonalizado(Func<T, bool> logica, params Expression<Func<T, object>>[] modelos)
        {
            return _unitOfWork.Repository.ListaDeModeloPersonalizado(logica, modelos);
        }
        
        public T RetornaModelo(Func<T, bool> logica, params Expression<Func<T, object>>[] modelos)
        {
            return _unitOfWork.Repository.RetornaModelo(logica, modelos);
        }
    }
}