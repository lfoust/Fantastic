﻿namespace Fantastic.TheMovieDb.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class KeywordsContainer
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("keywords")]
        public List<Keyword> Keywords { get; set; } = new List<Keyword>();
    }
}
