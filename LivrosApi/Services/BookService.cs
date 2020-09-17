using LivrosApi.Data;
using LivrosApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace LivrosApi.Services
{
    public class BookService : IBookService
    {

        private IBookRepository Repository { get; set; }

        public BookService(IBookRepository repository)
        {
            Repository = repository;
        }

        public List<Book> BuscarLivros(BookSearch busca, string path = "")
        {
            List<Book> books = Repository.Data(path);

            books = books.Where(x =>
            (string.IsNullOrWhiteSpace(busca.Name) || RemoveDiacritics(x.Name).Contains(RemoveDiacritics(busca.Name)))
            && (string.IsNullOrWhiteSpace(busca.Author) || RemoveDiacritics(x.Specifications.Author).Contains(RemoveDiacritics(busca.Author)))
            && (string.IsNullOrWhiteSpace(busca.Illustrator) || x.Specifications.Illustrator.Any(i => RemoveDiacritics(i).Contains(RemoveDiacritics(busca.Illustrator))))
            && (string.IsNullOrWhiteSpace(busca.Genres) || x.Specifications.Genres.Any(g => RemoveDiacritics(g).Contains(RemoveDiacritics(busca.Genres))))
            && (busca.MinPrice == null || x.Price >= busca.MinPrice)
            && (busca.MaxPrice == null || x.Price <= busca.MaxPrice)
            && (busca.MinPage == null || x.Specifications.PageCount >= busca.MinPage)
            && (busca.MaxPage == null || x.Specifications.PageCount <= busca.MaxPage)
            ).ToList();

            books.ForEach(x => x.ShippingFee = Math.Round(x.Price * 0.2, 2));

            if (!string.IsNullOrWhiteSpace(busca.Order))
            {
                if (busca.Order == "asc")
                    books = books.OrderBy(x => x.Price).ToList();
                else if (busca.Order == "desc")
                    books = books.OrderByDescending(x => x.Price).ToList();
            }

            return books;
        }

        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            var retorno = new string(chars).Normalize(NormalizationForm.FormC);

            return retorno.ToUpper();
        }

    }

}

