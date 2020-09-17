using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LivrosApi.Models
{
    public class Specifications
    {
        [JsonPropertyName("Originally published")]
        public string OriginallyPublished { get; set; }
        public string Author { get; set; }
        [JsonPropertyName("Page count")]
        public int PageCount { get; set; }
        public List<string> Illustrator { get; set; }
        public List<string> Genres { get; set; }
    }

   
}
