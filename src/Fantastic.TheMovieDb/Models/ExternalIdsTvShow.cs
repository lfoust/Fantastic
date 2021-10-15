namespace Fantastic.TheMovieDb.Models
{
    using Fantastic.TheMovieDb.Serialization;
    using System.Text.Json.Serialization;

    public class ExternalIdsTvShow : ExternalIds
    {
        [JsonPropertyName("imdb_id")]
        public string? ImdbId { get; set; }

        [JsonPropertyName("tvdb_id")]
        [JsonConverter(typeof(NumberOrStringConverter))]
        public string? TvdbId { get; set; }

        [JsonPropertyName("facebook_id")]
        public string? FacebookId { get; set; }

        [JsonPropertyName("twitter_id")]
        public string? TwitterId { get; set; }

        [JsonPropertyName("instagram_id")]
        public string? InstagramId { get; set; }
    }
}
