namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class AlternativeTitle
    {
        /// <summary>
        /// A country code, e.g. US
        /// </summary>
        [JsonPropertyName("iso_3166_1")]
        public string? Iso_3166_1 { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }
    }
}
