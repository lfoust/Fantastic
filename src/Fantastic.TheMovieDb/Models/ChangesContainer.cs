namespace Fantastic.TheMovieDb.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ChangesContainer
    {
        [JsonPropertyName("changes")]
        public List<Change> Changes { get; set; } = new List<Change>();
    }
}
