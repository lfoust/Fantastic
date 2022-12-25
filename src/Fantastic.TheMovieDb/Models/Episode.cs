namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class Episode
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("air_date")]
        public string? AirDate { get; set; }

        [JsonPropertyName("episode_number")]
        public int EpisodeNumber { get; set; }

        [JsonPropertyName("season_number")]
        public int SeasonNumber { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("overview")]
        public string? Overview { get; set; }

        [JsonPropertyName("production_code")]
        public string? ProductionCode { get; set; }

        [JsonPropertyName("still_path")]
        public string? StillPath { get; set; }

        [JsonPropertyName("vote_average")]
        public float VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }
    }
}
