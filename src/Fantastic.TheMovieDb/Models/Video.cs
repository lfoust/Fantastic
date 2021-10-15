namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class Video
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// A country code, e.g. US
        /// </summary>
        [JsonPropertyName("iso_3166_1")]
        public string? Iso_3166_1 { get; set; }

        /// <summary>
        /// A language code, e.g. en
        /// </summary>
        [JsonPropertyName("iso_639_1")]
        public string? Iso_639_1 { get; set; }

        [JsonPropertyName("key")]
        public string? Key { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("site")]
        public string? Site { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
