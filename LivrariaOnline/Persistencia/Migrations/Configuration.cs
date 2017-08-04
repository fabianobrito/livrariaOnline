namespace Persistencia.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Persistencia.ContextoDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Persistencia.ContextoDB context)
        {
            context.Categorias.AddOrUpdate(
              p => p.id,
              new Modelo.Categorias.Categorias { id = 1, descricao="Ação" },
              new Modelo.Categorias.Categorias { id = 2, descricao = "Aventura" },
              new Modelo.Categorias.Categorias { id = 3, descricao = "Comédia" },
              new Modelo.Categorias.Categorias { id = 4, descricao = "Romance" },
              new Modelo.Categorias.Categorias { id = 5, descricao = "Terror" },
              new Modelo.Categorias.Categorias { id = 6, descricao = "Suspense" },
              new Modelo.Categorias.Categorias { id = 7, descricao = "Drama" }
            );
            //
        }
    }
}