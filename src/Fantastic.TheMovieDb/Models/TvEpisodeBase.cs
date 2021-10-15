namespace Fantastic.TheMovieDb.Models
{
    using Fantastic.TheMovieDb.Serialization;
    using System;
    using System.Text.Json.Serialization;

    public class TvEpisodeBase : TvEpisodeInfo
    {
        [JsonPropertyName("air_date")]
        [JsonConverter(typeof(NullableDateConverter))]
        public DateTimeOffset? AirDate { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("overview")]
        public string? Overview { get; set; }

        [JsonPropertyName("production_code")]
        public string? ProductionCode { get; set; }

        [JsonPropertyName("show_id")]
        public int ShowId { get; set; }

        [JsonPropertyName("still_path")]
        public string? StillPath { get; set; }

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }
    }
}
