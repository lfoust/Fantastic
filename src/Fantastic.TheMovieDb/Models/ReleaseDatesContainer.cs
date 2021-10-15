namespace Fantastic.TheMovieDb.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ReleaseDatesContainer
    {
        /// <summary>
        /// A country code, e.g. US
        /// </summary>
        [JsonPropertyName("iso_3166_1")]
        public string? Iso_3166_1 { get; set; }

        [JsonPropertyName("release_dates")]
        public List<ReleaseDateItem> ReleaseDates { get; set; } = new List<ReleaseDateItem>();
    }
}
