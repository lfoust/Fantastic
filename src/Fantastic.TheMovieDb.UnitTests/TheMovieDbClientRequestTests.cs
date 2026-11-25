namespace Fantastic.TheMovieDb.UnitTests;

using System.Net;
using System.Text;
using Fantastic.TheMovieDb.Caching.FileSystem;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

public class TheMovieDbClientRequestTests
{
    [Theory]
    [InlineData(HttpStatusCode.NotFound)]
    [InlineData(HttpStatusCode.TooManyRequests)]
    [InlineData(HttpStatusCode.ServiceUnavailable)]
    public async Task GetMovie_HttpFailure_PreservesStatusAndRetries(HttpStatusCode status)
    {
        using var handler = new SequenceHandler(
            Response(status, """{"status_message":"Request failed"}"""),
            Response(HttpStatusCode.OK, """{"id":9549,"title":"The Right Stuff"}"""));
        using var http = new HttpClient(handler);
        using var memory = new MemoryCache(new MemoryCacheOptions());
        using var client = CreateClient(http, new InMemoryFileSystemCache(memory));

        var error = await Assert.ThrowsAsync<HttpRequestException>(() => client.GetMovie("9549"));
        Assert.Equal(status, error.StatusCode);
        Assert.DoesNotContain("test-api-key", error.Message);

        var movie = await client.GetMovie("9549");
        var cached = await client.GetMovie("9549");

        Assert.Equal("The Right Stuff", movie.Title);
        Assert.Same(movie, cached);
        Assert.Equal(2, handler.Calls);
    }

    [Fact]
    public async Task GetMovie_NullResponse_DoesNotCacheAndRetries()
    {
        using var handler = new SequenceHandler(
            Response(HttpStatusCode.OK, "null"),
            Response(HttpStatusCode.OK, """{"id":9549,"title":"The Right Stuff"}"""));
        using var http = new HttpClient(handler);
        using var memory = new MemoryCache(new MemoryCacheOptions());
        using var client = CreateClient(http, new InMemoryFileSystemCache(memory));

        Assert.Null(await client.GetMovie("9549"));
        Assert.Equal("The Right Stuff", (await client.GetMovie("9549")).Title);
        Assert.Equal(2, handler.Calls);
    }

    [Fact]
    public async Task GetMovie_InvalidJson_DoesNotCacheAndRetries()
    {
        using var handler = new SequenceHandler(
            Response(HttpStatusCode.OK, "{"),
            Response(HttpStatusCode.OK, """{"id":9549,"title":"The Right Stuff"}"""));
        using var http = new HttpClient(handler);
        using var memory = new MemoryCache(new MemoryCacheOptions());
        using var client = CreateClient(http, new InMemoryFileSystemCache(memory));

        await Assert.ThrowsAsync<ResponseJsonException>(() => client.GetMovie("9549"));
        Assert.Equal("The Right Stuff", (await client.GetMovie("9549")).Title);
        Assert.Equal(2, handler.Calls);
    }

    [Fact]
    public async Task GetMovie_CancelledDuringRequest_CancelsTransport()
    {
        using var handler = new BlockingHandler();
        using var http = new HttpClient(handler);
        using var client = CreateClient(http, new NullFileSystemCache());
        using var cancellation = new CancellationTokenSource();

        var lookup = client.GetMovie("9549", cancellationToken: cancellation.Token);
        await handler.Started.Task.WaitAsync(TimeSpan.FromSeconds(5));
        cancellation.Cancel();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(
            () => lookup.WaitAsync(TimeSpan.FromSeconds(5)));
        Assert.True(handler.TransportToken.IsCancellationRequested);
    }

    private static TheMovieDbClient CreateClient(HttpClient http, IFileSystemCache cache)
        => new(http, new TestOptions(new TheMovieDbOptions { ApiKey = "test-api-key" }),
            NullLoggerFactory.Instance, cache);

    private static HttpResponseMessage Response(HttpStatusCode status, string json)
        => new(status) { Content = new StringContent(json, Encoding.UTF8, "application/json") };

    private sealed class SequenceHandler(params HttpResponseMessage[] responses) : HttpMessageHandler
    {
        public int Calls { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => Task.FromResult(responses[Calls++]);
    }

    private sealed class BlockingHandler : HttpMessageHandler
    {
        public TaskCompletionSource Started { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public CancellationToken TransportToken { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            TransportToken = cancellationToken;
            Started.SetResult();
            await Task.Delay(Timeout.Infinite, cancellationToken);
            throw new InvalidOperationException("The request should have been cancelled.");
        }
    }

    private sealed class TestOptions(TheMovieDbOptions value) : IOptionsMonitor<TheMovieDbOptions>
    {
        public TheMovieDbOptions CurrentValue => value;
        public TheMovieDbOptions Get(string? name) => value;
        public IDisposable? OnChange(Action<TheMovieDbOptions, string?> listener) => null;
    }
}
