namespace Fantastic.TheMovieDb.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Images
    {
        [JsonPropertyName("backdrops")]
        public List<ImageData> Backdrops { get; set; } = new List<ImageData>();

        [JsonPropertyName("posters")]
        public List<ImageData> Posters { get; set; } = new List<ImageData>();
    }
}
