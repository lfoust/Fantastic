namespace Fantastic.TheMovieDb.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class TranslationsContainer
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("translations")]
        public List<Translation> Translations { get; set; } = new List<Translation>();
    }
}
