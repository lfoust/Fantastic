namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class SearchCollection
    {
        [JsonPropertyName("backdrop_path")]
        public string? BackdropPath { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }
    }
}
