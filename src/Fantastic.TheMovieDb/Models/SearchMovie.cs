namespace Fantastic.TheMovieDb.Models
{
    using System;
    using System.Text.Json.Serialization;

    public class SearchMovie : SearchMovieTvBase
    {
        [JsonPropertyName("adult")]
        public bool Adult { get; set; }

        [JsonPropertyName("original_title")]
        public string? OriginalTitle { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("video")]
        public bool Video { get; set; }
    }
}
