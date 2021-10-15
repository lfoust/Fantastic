namespace Fantastic.TheMovieDb.Models
{
    using Fantastic.TheMovieDb.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Series
    {
        [JsonPropertyName("account_states")]
        public AccountState AccountStates { get; set; } = new AccountState();

        [JsonPropertyName("alternative_titles")]
        public ResultContainer<AlternativeTitle> AlternativeTitles { get; set; } = new ResultContainer<AlternativeTitle>();

        [JsonPropertyName("backdrop_path")]
        public string? BackdropPath { get; set; }

        [JsonPropertyName("changes")]
        public ChangesContainer Changes { get; set; } = new ChangesContainer();

        [JsonPropertyName("content_ratings")]
        public ResultContainer<ContentRating> ContentRatings { get; set; } = new ResultContainer<ContentRating>();

        [JsonPropertyName("created_by")]
        public List<CreatedBy> CreatedBy { get; set; } = new List<CreatedBy>();

        [JsonPropertyName("credits")]
        public Credits Credits { get; set; } = new Credits();

        [JsonPropertyName("episode_run_time")]
        public List<int> EpisodeRunTime { get; set; } = new List<int>();

        [JsonPropertyName("external_ids")]
        public ExternalIdsTvShow ExternalIds { get; set; } = new ExternalIdsTvShow();

        [JsonPropertyName("first_air_date")]
        [JsonConverter(typeof(NullableDateConverter))]
        public DateTimeOffset? FirstAirDate { get; set; }

        [JsonPropertyName("genre_ids")]
        public List<int> GenreIds { get; set; } = new List<int>();

        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; } = new List<Genre>();

        [JsonPropertyName("homepage")]
        public string? Homepage { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("images")]
        public Images Images { get; set; } = new Images();

        [JsonPropertyName("in_production")]
        public bool InProduction { get; set; }

        [JsonPropertyName("keywords")]
        public ResultContainer<Keyword> Keywords { get; set; } = new ResultContainer<Keyword>();

        /// <summary>
        /// language ISO code ex. en
        /// </summary>
        [JsonPropertyName("languages")]
        public List<string> Languages { get; set; } = new List<string>();

        [JsonPropertyName("last_air_date")]
        [JsonConverter(typeof(NullableDateConverter))]
        public DateTimeOffset? LastAirDate { get; set; }

        [JsonPropertyName("last_episode_to_air")]
        public TvEpisodeBase LastEpisodeToAir { get; set; } = new TvEpisodeBase();

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("next_episode_to_air")]
        public TvEpisodeBase NextEpisodeToAir { get; set; } = new TvEpisodeBase();

        [JsonPropertyName("networks")]
        public List<NetworkWithLogo> Networks { get; set; } = new List<NetworkWithLogo>();

        [JsonPropertyName("number_of_episodes")]
        public int? NumberOfEpisodes { get; set; }

        [JsonPropertyName("number_of_seasons")]
        public int NumberOfSeasons { get; set; }

        [JsonPropertyName("original_language")]
        public string? OriginalLanguage { get; set; }

        [JsonPropertyName("original_name")]
        public string? OriginalName { get; set; }

        /// <summary>
        /// Country ISO code ex. US
        /// </summary>
        [JsonPropertyName("origin_country")]
        public List<string> OriginCountry { get; set; } = new List<string>();

        [JsonPropertyName("overview")]
        public string? Overview { get; set; }

        [JsonPropertyName("popularity")]
        public double Popularity { get; set; }

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }

        [JsonPropertyName("production_companies")]
        public List<ProductionCompany> ProductionCompanies { get; set; } = new List<ProductionCompany>();

        [JsonPropertyName("seasons")]
        public List<SearchTvSeason> Seasons { get; set; } = new List<SearchTvSeason>();

        [JsonPropertyName("reviews")]
        public SearchContainer<ReviewBase> Reviews { get; set; } = new SearchContainer<ReviewBase>();

        [JsonPropertyName("similar")]
        public ResultContainer<Series> Similar { get; set; } = new ResultContainer<Series>();

        [JsonPropertyName("recommendations")]
        public ResultContainer<Series> Recommendations { get; set; } = new ResultContainer<Series>();

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("translations")]
        public TranslationsContainer Translations { get; set; } = new TranslationsContainer();

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("videos")]
        public ResultContainer<Video> Videos { get; set; } = new ResultContainer<Video>();

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }
    }
}
