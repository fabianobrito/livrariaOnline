using Persistencia.Migrations;
using System.Data.Entity;

namespace Persistencia
{
    public class ContextoDB : DbContext
    {
        public ContextoDB() : base("livraria")
        {
            Database.SetInitializer<ContextoDB>(new MigrateDatabaseToLatestVersion<ContextoDB, Configuration>());
        }
        public DbSet<Modelo.Livros.Livros> Livros { get; set; }
        public DbSet<Modelo.Categorias.Categorias> Categorias { get; set; }
    }
}
