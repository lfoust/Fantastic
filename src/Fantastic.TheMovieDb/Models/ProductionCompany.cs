namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class ProductionCompany
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("logo_path")]
        public string? LogoPath { get; set; }

        [JsonPropertyName("origin_country")]
        public string? OriginCountry { get; set; }
    }
}
