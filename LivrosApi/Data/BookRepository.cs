using LivrosApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LivrosApi.Data
{
    public class BookRepository : IBookRepository
    {
        public List<Book> Data(string path)
        {
            string jsonPath = "../LivrosApi/Data/books.json";
            if (!string.IsNullOrWhiteSpace(path))
                jsonPath = path;

            var json = File.ReadAllText(jsonPath);
            return JsonSerializer.Deserialize<List<Book>>(json);
        }
    }
}
