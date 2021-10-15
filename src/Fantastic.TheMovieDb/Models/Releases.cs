namespace Fantastic.TheMovieDb.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Releases
    {
        [JsonPropertyName("countries")]
        public List<Country> Countries { get; set; } = new List<Country>();

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
