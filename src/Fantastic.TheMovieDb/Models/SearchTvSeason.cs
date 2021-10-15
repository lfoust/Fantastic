﻿namespace Fantastic.TheMovieDb.Models
{
    using Fantastic.TheMovieDb.Serialization;
    using System;
    using System.Text.Json.Serialization;

    public class SearchTvSeason
    {
        [JsonPropertyName("air_date")]
        [JsonConverter(typeof(NullableDateConverter))]
        public DateTimeOffset? AirDate { get; set; }

        [JsonPropertyName("episode_count")]
        public int EpisodeCount { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("overview")]
        public string? Overview { get; set; }

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }

        [JsonPropertyName("season_number")]
        public int SeasonNumber { get; set; }
    }
}
