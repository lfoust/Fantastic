namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class SearchBase
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("media_type")]
        public string? MediaType { get; set; } // TODO: Use an enum?

        [JsonPropertyName("popularity")]
        public double Popularity { get; set; }
    }
}
