namespace Fantastic.TheMovieDb.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Season
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("air_date")]
        public string? AirDate { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("overview")]
        public string? Overview { get; set; }

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }

        [JsonPropertyName("season_number")]
        public int SeasonNumber { get; set; }

        public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
