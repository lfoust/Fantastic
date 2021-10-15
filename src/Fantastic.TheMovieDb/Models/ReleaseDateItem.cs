namespace Fantastic.TheMovieDb.Models
{
    using System;
    using System.Text.Json.Serialization;

    public class ReleaseDateItem
    {
        [JsonPropertyName("certification")]
        public string? Certification { get; set; }

        /// <summary>
        /// A language code, e.g. en
        /// </summary>
        [JsonPropertyName("iso_639_1")]
        public string? Iso_639_1 { get; set; }

        [JsonPropertyName("note")]
        public string? Note { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
