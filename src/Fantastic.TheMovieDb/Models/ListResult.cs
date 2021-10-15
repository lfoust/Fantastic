namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class ListResult
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("favorite_count")]
        public int FavoriteCount { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>A language code, e.g. en</summary>
        [JsonPropertyName("iso_639_1")]
        public string? Iso_639_1 { get; set; }

        [JsonPropertyName("item_Count")]
        public int ItemCount { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }
    }
}
