namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class ExternalIdsMovie
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("imdb_id")]
        public string? ImdbId { get; set; }

        [JsonPropertyName("facebook_id")]
        public string? FacebookId { get; set; }

        [JsonPropertyName("twitter_id")]
        public string? TwitterId { get; set; }

        [JsonPropertyName("instagram_id")]
        public string? InstagramId { get; set; }
    }
}
