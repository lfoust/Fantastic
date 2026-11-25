namespace Fantastic.TheMovieDb.UnitTests;

using Fantastic.TheMovieDb.Caching.FileSystem;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

public class TheMovieDbClientCacheTests
{
    [Fact]
    public async Task GetMovieAndSeries_WithSameId_UseDistinctCacheKeys()
    {
        var cache = new RecordingCache();
        using var client = CreateClient(cache);

        await client.GetMovie("4614");
        await client.GetSeries("4614");

        Assert.Equal(["movie-4614", "tv-4614"], cache.Keys);
    }

    [Fact]
    public async Task GetMovie_WithDifferentLanguages_UsesDistinctCacheKeys()
    {
        var cache = new RecordingCache();
        using var client = CreateClient(cache);

        await client.GetMovie("4614", "en-us");
        await client.GetMovie("4614", "fr-fr");

        Assert.Equal(["movie-4614-en-US", "movie-4614-fr-FR"], cache.Keys);
    }

    private static TheMovieDbClient CreateClient(IFileSystemCache cache)
    {
        return new TheMovieDbClient(
            new HttpClient(new ThrowingHttpMessageHandler()),
            new TestOptionsMonitor<TheMovieDbOptions>(new TheMovieDbOptions()),
            NullLoggerFactory.Instance,
            cache);
    }

    private sealed class RecordingCache : IFileSystemCache
    {
        public List<string> Keys { get; } = [];

        public Task<T?> TryGet<T>(string cacheKey, Func<Task<T>> refresh, CancellationToken cancellationToken)
        {
            this.Keys.Add(cacheKey);
            return Task.FromResult(default(T));
        }
    }

    private sealed class ThrowingHttpMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            throw new InvalidOperationException("The cache test should not issue an HTTP request.");
        }
    }

    private sealed class TestOptionsMonitor<T>(T value) : IOptionsMonitor<T>
    {
        public T CurrentValue => value;

        public T Get(string? name) => value;

        public IDisposable? OnChange(Action<T, string?> listener) => null;
    }
}
