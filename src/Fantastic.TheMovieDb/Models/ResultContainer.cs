namespace Fantastic.TheMovieDb.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ResultContainer<T>
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("results")]
        public List<T> Results { get; set; } = new List<T>();
    }
}
