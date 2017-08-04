using Modelo.Livros;
using Persistencia;
using Servico;
using Servico.Livros;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LivrariaApp.Controllers
{
    public class LivrosController : ApiController
    {
        private Servico<Livros> _servico;
        public LivrosController()
        {
            _servico = new LivroServico(new UnitOfWork<Livros>(new ContextoDB()));
        }

        [ResponseType(typeof(Livros))]
        [HttpGet]
        [Route("pesquisarLivro")]
        public IHttpActionResult RetornaLivro(string titulo, string isbn, string autor)
        {
            var livros = _servico.ListaDeModeloPersonalizado(l => l.titulo.Equals(titulo) ||
            l.ISBN.Equals(isbn) || l.autor.Equals(autor));

            if (livros == null)
            {
                return NotFound();
            }
            return Ok(livros);
        }

        [HttpGet]
        [Route("RetornaTodosOsLivros")]
        public List<Livros> RetornaTodosOsLivros()
        {
            return _servico.ListaDeModelo(l => l.categoria);
        }

        [HttpPut]
        [Route("AtualizaLivro")]
        public IHttpActionResult AtualizaLivro([FromBody]Livros objeto)
        {
            Livros livro = _servico.RetornaModelo(l => l.id == objeto.id);

            if (livro != null)
            {
                livro.autor = objeto.autor;
                livro.titulo = objeto.titulo;
                livro.ISBN = objeto.ISBN;
                livro.categoriaID = objeto.categoriaID;
                livro.editora = objeto.editora;
                livro.idioma = objeto.idioma;
                livro.ano = objeto.ano;
                livro.numeroEd = objeto.numeroEd;
                livro.descricao = objeto.descricao;
                _servico.Alterar(livro);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
            else
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Livro não localizado para alteração."));
        }

        [HttpDelete]
        [Route("ExcluirLivro")]
        public IHttpActionResult ExcluirLivro(int id)
        {
            Livros livro = _servico.RetornaModelo(l => l.id == id);

            if (livro != null)
            {
                _servico.Remover(livro);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
            else
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Livro não localizado para exclusão!"));
        }

        [HttpPost]
        [Route("AdicionarLivro")]
        public IHttpActionResult AdicionarLivro([FromBody]Livros objeto)
        {
            Livros livro = _servico.RetornaModelo(l => l.id == objeto.id);

            if (livro == null)
            {
                livro.autor = objeto.autor;
                livro.titulo = objeto.titulo;
                livro.ISBN = objeto.ISBN;
                livro.categoriaID = objeto.categoriaID;
                livro.editora = objeto.editora;
                livro.idioma = objeto.idioma;
                livro.ano = objeto.ano;
                livro.numeroEd = objeto.numeroEd;
                livro.descricao = objeto.descricao;
                _servico.Adicionar(livro);

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
            else
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.Conflict, "Livro já foi cadastrado!"));
        }
    }
}