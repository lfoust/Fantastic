namespace Fantastic.TheMovieDb.Models
{
    using Fantastic.TheMovieDb.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class SearchTv : SearchMovieTvBase
    {
        [JsonPropertyName("first_air_date")]
        [JsonConverter(typeof(NullableDateConverter))]
        public DateTimeOffset? FirstAirDate { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("original_name")]
        public string? OriginalName { get; set; }

        /// <summary>Country ISO code ex. US</summary>
        [JsonPropertyName("origin_country")]
        public List<string> OriginCountry { get; set; } = new List<string>();
    }
}
