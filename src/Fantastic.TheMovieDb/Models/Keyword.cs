namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class Keyword
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
