namespace Fantastic.TheMovieDb.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Credits
    {
        [JsonPropertyName("cast")]
        public List<Cast> Cast { get; set; } = new List<Cast>();

        [JsonPropertyName("crew")]
        public List<Crew> Crew { get; set; } = new List<Crew>();

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
