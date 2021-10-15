namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class TvEpisodeInfo
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("season_number")]
        public int SeasonNumber { get; set; }

        [JsonPropertyName("episode_number")]
        public int EpisodeNumber { get; set; }
    }
}
