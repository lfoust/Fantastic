namespace Fantastic.TheMovieDb.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Change
    {
        [JsonPropertyName("items")]
        public List<ChangeItemBase> Items { get; set; } = new List<ChangeItemBase>();

        [JsonPropertyName("key")]
        public string? Key { get; set; }
    }
}
