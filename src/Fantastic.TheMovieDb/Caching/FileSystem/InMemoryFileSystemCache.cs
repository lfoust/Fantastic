namespace Fantastic.TheMovieDb.Caching.FileSystem;

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

public class InMemoryFileSystemCache : IFileSystemCache
{
    private readonly IMemoryCache cache;

    public InMemoryFileSystemCache(IMemoryCache cache)
    {
        this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<T?> TryGet<T>(string cacheKey, Func<Task<T>> refresh, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (this.cache.TryGetValue<T>(cacheKey, out var cached) && cached is not null)
        {
            return cached;
        }

        var value = await refresh();
        cancellationToken.ThrowIfCancellationRequested();
        if (value is not null)
        {
            this.cache.Set(cacheKey, value, TimeSpan.FromHours(10));
        }

        return value;
    }
}
