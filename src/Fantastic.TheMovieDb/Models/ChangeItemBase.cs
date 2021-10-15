namespace Fantastic.TheMovieDb.Models
{
    using System;
    using System.Text.Json.Serialization;

    public abstract class ChangeItemBase
    {
        [JsonPropertyName("action")]
        public string? Action { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// A language code, e.g. en
        /// This field is not always set
        /// </summary>
        [JsonPropertyName("iso_639_1")]
        public string? Iso_639_1 { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
    }
}
