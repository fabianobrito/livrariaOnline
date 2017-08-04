using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Persistencia
{
    public interface IRepository<T> where T : class
    {
        void Adicionar(params T[] modelos);        
        void Alterar(params T[] modelos);
        void Remover(params T[] modelos);
        List<T> ListaDeModelo(params Expression<Func<T, object>>[] modelos);
        List<T> ListaDeModeloPersonalizado(Func<T, bool> logica, params Expression<Func<T, object>>[] modelos);
        T RetornaModelo(Func<T, bool> logica, params Expression<Func<T, object>>[] modelos);
    }
}