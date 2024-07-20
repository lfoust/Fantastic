namespace Fantastic.TheMovieDb
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Text.Json;
    using Microsoft.AspNetCore.WebUtilities;
    using TheMovieDb.Models;
    using TheMovieDb.Caching.FileSystem;

    public class TheMovieDbClient : IDisposable
    {
        public const string BaseTmdbUrl = "https://www.themoviedb.org/";
        public const string BaseTmdbApiUrl = "https://api.themoviedb.org/";
        public const string ProviderName = "TheMovieDb";
        public const string AcceptHeader = "application/json";

        private const string ApiVersion = "3";
        private const string GetItemByIdUrlFormat = BaseTmdbApiUrl + ApiVersion + "/{0}/{1}";
        private const string SearchUrl = BaseTmdbApiUrl + ApiVersion + "/search/{0}";
        private const string GetSeasonUrl = BaseTmdbApiUrl + ApiVersion + "/tv/{0}/season/{1}";
        private const string GetEpisodeUrl = BaseTmdbApiUrl + ApiVersion + "/tv/{0}/season/{1}/episode/{2}";
        private const string GetMovieCreditsUrl = BaseTmdbApiUrl + ApiVersion + "/movie/{0}/credits";

        private readonly HttpClient client;
        private readonly IOptionsMonitor<TheMovieDbOptions> options;
        private readonly IFileSystemCache cache;
        private ILogger logger;

        public TheMovieDbClient(HttpClient client, IOptionsMonitor<TheMovieDbOptions> options, ILoggerFactory loggerFactory, IFileSystemCache cache)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
            logger = loggerFactory == null ? throw new ArgumentNullException(nameof(loggerFactory)) : loggerFactory.CreateLogger(GetType());
        }

        public async Task<SearchContainer<SearchMovie>> SearchMovieAsync(string query, string? language = null, int page = 0, bool includeAdult = false, int year = 0, CancellationToken cancellationToken = default)
        {
            return await SearchMethod<SearchContainer<SearchMovie>>("movie", query, page, language, includeAdult, year, "yyyy-MM-dd", cancellationToken).ConfigureAwait(false);
        }

        public async Task<SearchContainer<SearchTv>> SearchTvShowAsync(string query, string? language = null, int page = 0, CancellationToken cancellationToken = default)
        {
            return await SearchMethod<SearchContainer<SearchTv>>("tv", query, page, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public Task<Season> GetSeason(int id, int season, string? language = null, CancellationToken cancellationToken = default)
        {
            string url = string.Format(GetSeasonUrl, id, season);

            var param = new Dictionary<string, string>
            {
                { "api_key", options.CurrentValue.ApiKey }
            };

            language = language ?? options.CurrentValue.DefaultLanguage;
            if (!string.IsNullOrWhiteSpace(language))
            {
                param.Add("language", NormalizeLanguage(language));
            }

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));
            return MakeRequest<Season>(newUrl.ToString(), cancellationToken);
        }

        public Task<Episode> GetEpisode(int id, int season, int episode, string? language = null, CancellationToken cancellationToken = default)
        {
            string url = string.Format(GetEpisodeUrl, id, season, episode);

            var param = new Dictionary<string, string>
            {
                { "api_key", options.CurrentValue.ApiKey }
            };

            language = language ?? options.CurrentValue.DefaultLanguage;
            if (!string.IsNullOrWhiteSpace(language))
            {
                param.Add("language", NormalizeLanguage(language));
            }

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));
            return MakeRequest<Episode>(newUrl.ToString(), cancellationToken);
        }

        private Task<T> SearchMethod<T>(string method, string query, int page, string? language = null, bool? includeAdult = null, int year = 0, string? dateFormat = null, CancellationToken cancellationToken = default) 
            where T : new()
        {
            var url = string.Format(SearchUrl, method);

            var param = new Dictionary<string, string>
            {
                { "api_key", options.CurrentValue.ApiKey },
                { "query", query }
            };

            language = language ?? options.CurrentValue.DefaultLanguage;
            if (!string.IsNullOrWhiteSpace(language))
            {
                param.Add("language", NormalizeLanguage(language));
            }

            if (page >= 1)
            {
                param.Add("page", page.ToString());
            }

            if (year >= 1)
            {
                param.Add("year", year.ToString());
            }

            if (includeAdult.HasValue)
            {
                param.Add("include_adult", includeAdult.Value ? "true" : "false");
            }

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));
            return MakeRequest<T>(newUrl.ToString(), cancellationToken);
        }

        private async Task<T> MakeRequest<T>(string url, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(AcceptHeader));

            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    return await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
                }
                catch (NotSupportedException notSupportedException) // When content type is not valid
                {
                    logger.LogError(notSupportedException, "IMDB: Content type not supported");
                }
                catch (JsonException invalidJsonException) // Invalid JSON
                {
                    logger.LogError(invalidJsonException, "IMDB: Invalid JSON in response");
                }
            }

            return default;
        }

        public async Task<Movie> GetMovie(string id, string? language = null, CancellationToken cancellationToken = default)
        {
            return await GetItemById<Movie>(id, "movie", "credits,external_ids,releases,images,keywords", language, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Series> GetSeries(string id, string? language = null, CancellationToken cancellationToken = default)
        {
            return await GetItemById<Series>(id, "tv", "credits,external_ids,content_ratings,keywords", language, cancellationToken).ConfigureAwait(false);
        }

        public Task<Credits> GetMovieCredits(string id, string? language = null, CancellationToken cancellationToken = default)
        {
            string url = string.Format(GetMovieCreditsUrl, id);

            var param = new Dictionary<string, string>
            {
                { "api_key", options.CurrentValue.ApiKey }
            };

            language = language ?? options.CurrentValue.DefaultLanguage;
            if (!string.IsNullOrWhiteSpace(language))
            {
                param.Add("language", NormalizeLanguage(language));
            }

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));
            return MakeRequest<Credits>(newUrl.ToString(), cancellationToken);
        }

        private Task<T> GetItemById<T>(string id, string urlName, string appendToResponse, string? language = null, CancellationToken cancellationToken = default)
        {
            return cache.TryGet(id, async () =>
            {
                var url = string.Format(GetItemByIdUrlFormat, urlName, id);

                var param = new Dictionary<string, string>
            {
                { "api_key", options.CurrentValue.ApiKey },
                { "append_to_response", appendToResponse }
            };

                language = language ?? options.CurrentValue.DefaultLanguage;
                if (!string.IsNullOrWhiteSpace(language))
                {
                    param.Add("language", NormalizeLanguage(language));
                    param.Add("include_image_language", GetImageLanguagesParam(language)); // Get images in english and with no language
                }

                var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));
                return await MakeRequest<T>(newUrl.ToString(), cancellationToken);
            }, cancellationToken);
        }

        public static string NormalizeLanguage(string language)
        {
            if (!string.IsNullOrEmpty(language))
            {
                // They require this to be uppercase
                // Everything after the hyphen must be written in uppercase due to a way TMDB wrote their api.
                // See here: https://www.themoviedb.org/talk/5119221d760ee36c642af4ad?page=3#56e372a0c3a3685a9e0019ab
                var parts = language.Split('-');

                if (parts.Length == 2)
                {
                    language = parts[0] + "-" + parts[1].ToUpperInvariant();
                }
            }

            return language;
        }

        public static string GetImageLanguagesParam(string preferredLanguage)
        {
            var languages = new List<string>();

            if (!string.IsNullOrEmpty(preferredLanguage))
            {
                preferredLanguage = NormalizeLanguage(preferredLanguage);

                languages.Add(preferredLanguage);

                if (preferredLanguage.Length == 5) // like en-US
                {
                    // Currenty, TMDB supports 2-letter language codes only
                    // They are planning to change this in the future, thus we're
                    // supplying both codes if we're having a 5-letter code.
                    languages.Add(preferredLanguage.Substring(0, 2));
                }
            }

            languages.Add("null");

            if (!string.Equals(preferredLanguage, "en", StringComparison.OrdinalIgnoreCase))
            {
                languages.Add("en");
            }

            return string.Join(",", languages.ToArray());
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
