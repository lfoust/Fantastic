namespace Fantastic.TheMovieDb.UnitTests;

using Fantastic.TheMovieDb.Caching.FileSystem;

public class NullFileSystemCacheTests
{
    [Fact]
    public async Task TryGet_UsesRefreshWithoutCaching()
    {
        var cache = new NullFileSystemCache();
        int refreshCount = 0;

        string? first = await cache.TryGet("movie-4614", Refresh, CancellationToken.None);
        string? second = await cache.TryGet("movie-4614", Refresh, CancellationToken.None);

        Assert.Equal("The Sum of All Fears", first);
        Assert.Equal("The Sum of All Fears", second);
        Assert.Equal(2, refreshCount);

        Task<string> Refresh()
        {
            refreshCount++;
            return Task.FromResult("The Sum of All Fears");
        }
    }
}
