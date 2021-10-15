namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class NetworkBase
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("origin_country")]
        public string? OriginCountry { get; set; }
    }
}
