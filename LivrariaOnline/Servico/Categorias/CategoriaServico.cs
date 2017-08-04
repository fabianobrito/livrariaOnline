using Persistencia;

namespace Servico.Categorias
{
    public class CategoriaServico : Servico<Modelo.Categorias.Categorias>
    {
        public CategoriaServico(UnitOfWork<Modelo.Categorias.Categorias> unitOfWork) : base(unitOfWork)
        {
        }
    }
}