namespace Fantastic.TheMovieDb.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class SearchContainer<T>
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<T> Results { get; set; } = new List<T>();

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
}
