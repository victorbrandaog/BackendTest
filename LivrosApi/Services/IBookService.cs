using LivrosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrosApi.Services
{
    public interface IBookService
    {
        List<Book> BuscarLivros(BookSearch busca, string path = "");
    }
}
