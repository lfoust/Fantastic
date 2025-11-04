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

    public Task<T?> TryGet<T>(string cacheKey, Func<Task<T>> refresh, CancellationToken cancellationToken)
    {
        return this.cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(10);
            return await refresh();
        });
    }
}
