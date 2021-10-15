namespace Fantastic.TheMovieDb.Models
{
    using System.Text.Json.Serialization;

    public class NetworkWithLogo : NetworkBase
    {
        [JsonPropertyName("logo_path")]
        public string? LogoPath { get; set; }
    }
}
