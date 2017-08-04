using System.Data.Entity;

namespace Persistencia.Categorias
{
    public class CategoriasRepository : Repository<Modelo.Categorias.Categorias>
    {
        public CategoriasRepository(DbContext contexto) : base(contexto)
        {
        }
    }
}
