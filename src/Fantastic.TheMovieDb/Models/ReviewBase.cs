namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class ReviewBase
    {
        [JsonPropertyName("author")]
        public string? Author { get; set; }

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
