namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class ImageData
    {
        [JsonPropertyName("aspect_ratio")]
        public double AspectRatio { get; set; }

        [JsonPropertyName("file_path")]
        public string? FilePath { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        /// <summary>A language code, e.g. en</summary>
        [JsonPropertyName("iso_639_1")]
        public string? Iso_639_1 { get; set; }

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}
