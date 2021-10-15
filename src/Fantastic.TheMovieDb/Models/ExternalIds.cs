namespace Fantastic.TheMovieDb.Models
{
    using Fantastic.TheMovieDb.Serialization;
    using System.Text.Json.Serialization;

    public class ExternalIds
    {
        [JsonPropertyName("freebase_id")]
        public string? FreebaseId { get; set; }

        [JsonPropertyName("freebase_mid")]
        public string? FreebaseMid { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("tvrage_id")]
        [JsonConverter(typeof(NumberOrStringConverter))]
        public string? TvrageId { get; set; }
    }
}
