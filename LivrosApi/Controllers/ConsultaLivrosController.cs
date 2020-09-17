using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrosApi.Models;
using LivrosApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultaLivrosController : ControllerBase
    {
        public IBookService BookService { get; set; }

        public ConsultaLivrosController(IBookService bookService)
        {
            BookService = bookService;
        }

        [HttpGet]
        public List<Book> Get([FromQuery] BookSearch busca)
        {
            return BookService.BuscarLivros(busca);
        }

    }
}
