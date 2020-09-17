using LivrosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrosApi.Data
{
    public interface IBookRepository
    {
        List<Book> Data(string path);
    }
}
