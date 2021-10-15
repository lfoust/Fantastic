namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class Translation
    {
        [JsonPropertyName("english_name")]
        public string? EnglishName { get; set; }

        /// <summary>
        /// A language code, e.g. en
        /// </summary>
        [JsonPropertyName("iso_639_1")]
        public string? Iso_639_1 { get; set; }

        [JsonPropertyName("iso_3166_1")]
        public string? Iso_3166_1 { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
