using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrosApi.Models
{
    public class BookSearch
    {
        public string Name { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public string Author { get; set; }
        public int? MinPage { get; set; }
        public int? MaxPage { get; set; }
        public string Illustrator { get; set; }
        public string Genres { get; set; }
        public string Order { get; set; }

        public BookSearch(){}

        public BookSearch(string name, double? minPrice, double? maxPrice, string author, int? minPage, int? maxPage, string illustrator, string genres, string order)
        {
            Name = name;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            Author = author;
            MinPage = minPage;
            MaxPage = maxPage;
            Illustrator = illustrator;
            Genres = genres;
            Order = order;
        }
    }
}
