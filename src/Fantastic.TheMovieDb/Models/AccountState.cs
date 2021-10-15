namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class AccountState
    {
        /// <summary>Gets or sets the current favorite status of the related movie for the current user session.</summary>
        [JsonPropertyName("favorite")]
        public bool Favorite { get; set; }

        /// <summary>Gets or sets the TMDb id for the related movie</summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("rating")]
        public double? Rating { get; set; }

        /// <summary>Gets or sets the presence of the related movie on the current user's watchlist.</summary>
        [JsonPropertyName("watchlist")]
        public bool Watchlist { get; set; }
    }
}
