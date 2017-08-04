using Persistencia;

namespace Servico.Livros
{
    public class LivroServico : Servico<Modelo.Livros.Livros>
    {
        public LivroServico(UnitOfWork<Modelo.Livros.Livros> unitOfWork) : base(unitOfWork)
        {
        }
    }
}