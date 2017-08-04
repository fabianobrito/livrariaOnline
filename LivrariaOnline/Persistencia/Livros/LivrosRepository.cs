using System.Data.Entity;

namespace Persistencia.Livros
{
    public class LivrosRepository : Repository<Modelo.Livros.Livros>
    {
        public LivrosRepository(DbContext contexto) : base(contexto)
        {
        }
    }
}
