namespace Fantastic.TheMovieDb.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class AlternativeTitles
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("titles")]
        public List<AlternativeTitle> Titles { get; set; } = new List<AlternativeTitle>();
    }
}
