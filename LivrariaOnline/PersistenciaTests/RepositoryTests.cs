using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Persistencia.Tests
{
    [TestClass()]
    public class RepositoryTests
    {
        private UnitOfWork<Modelo.Livros.Livros> _unitOfWork = new UnitOfWork<Modelo.Livros.Livros>(new ContextoDB());
        
        [TestMethod()]
        public void AdicionaLivro()
        {
            Modelo.Livros.Livros livro = new Modelo.Livros.Livros
            {
                titulo = "Construindo API Rest usando NODE.JS",
                autor = "Caio Ribeiro Pereira",
                ISBN = "9788555191503"
            };
            
            try
            {
                _unitOfWork.Repository.Adicionar(livro);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void ListarLivros()
        {
            try
            {
               List<Modelo.Livros.Livros> livros = _unitOfWork.Repository.ListaDeModelo(c=>c.categoria);
               Assert.IsTrue(livros.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}