namespace Fantastic.TheMovieDb.Models
{
    using System;
    using System.Text.Json.Serialization;

    public class Country
    {
        [JsonPropertyName("certification")]
        public string? Certification { get; set; }

        /// <summary>
        /// A country code, e.g. US
        /// </summary>
        [JsonPropertyName("iso_3166_1")]
        public string? Iso_3166_1 { get; set; }

        [JsonPropertyName("primary")]
        public bool Primary { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate { get; set; }
    }
}
