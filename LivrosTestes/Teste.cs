using LivrosApi.Data;
using LivrosApi.Models;
using LivrosApi.Services;
using NUnit.Framework;

namespace LivrosTestes
{
    public class Teste
    {
        private IBookService BookService { get; set; }
        private IBookRepository Repository { get; set; }
        private string path { get; set; }

        [SetUp]
        public void Setup()
        {
            Repository = new BookRepository();
            BookService = new BookService(Repository);
            path = "../../../../LivrosApi/Data/books.json";
        }


        [TestCase("", 5)]
        [TestCase("of the", 2)]
        [TestCase("and", 2)]
        [TestCase("Lord", 1)]
        [TestCase("Sea", 1)]
        [Test]
        public void TesteNome(string name, int count)
        {
            BookSearch busca = new BookSearch(name, null, null, null, null, null, null, null, null);

            var resultado = BookService.BuscarLivros(busca, path);
            Assert.AreEqual(count, resultado.Count);
        }


        [TestCase("Verne", 2)]
        [TestCase("Rowling", 2)]
        [TestCase("Tolkien", 1)]
        [TestCase("J.", 3)]
        [TestCase("K.", 2)]
        [Test]
        public void TesteAutor(string author, int count)
        {
            BookSearch busca = new BookSearch(null, null, null, author, null, null, null, null, null);

            var resultado = BookService.BuscarLivros(busca, path);
            Assert.AreEqual(count, resultado.Count);
        }

        [TestCase("Riou", 2)]
        [TestCase("Cliff", 2)]
        [TestCase("Tolkien", 1)]
        [TestCase("Mary", 1)]
        [TestCase("Mar", 2)]
        [Test]
        public void TesteIlustrador(string illustrator, int count)
        {
            BookSearch busca = new BookSearch(null, null, null, null, null, null, illustrator, null, null);

            var resultado = BookService.BuscarLivros(busca, path);
            Assert.AreEqual(count, resultado.Count);
        }


        [TestCase("fiction", 5)]
        [TestCase("adv", 3)]
        [TestCase("sci", 1)]
        [TestCase("bild", 1)]
        [TestCase("fantasy", 3)]
        [Test]
        public void TesteGenero(string genre, int count)
        {
            BookSearch busca = new BookSearch(null, null, null, null, null, null, null, genre, null);

            var resultado = BookService.BuscarLivros(busca, path);
            Assert.AreEqual(count, resultado.Count);
        }



        [TestCase(5, 12, 5)]
        [TestCase(6.5, 11, 3)]
        [TestCase(9, 10, 1)]
        [TestCase(10, 10.5, 2)]
        [TestCase(12, 15, 0)]
        [Test]
        public void TestePreco(double minPrice, double maxPrice, int count)
        {
            BookSearch busca = new BookSearch(null, minPrice, maxPrice, null, null, null, null, null, null);

            var resultado = BookService.BuscarLivros(busca, path);
            Assert.AreEqual(count, resultado.Count);
        }




        [TestCase(100, 850, 5)]
        [TestCase(200, 750, 4)]
        [TestCase(300, 650, 2)]
        [TestCase(400, 550, 1)]
        [TestCase(500, 700, 1)]
        [Test]
        public void TestePaginas(int minPag, int maxPag, int count)
        {
            BookSearch busca = new BookSearch(null, null, null, null, minPag, maxPag, null, null, null);

            var resultado = BookService.BuscarLivros(busca, path);
            Assert.AreEqual(count, resultado.Count);
        }
    }
}