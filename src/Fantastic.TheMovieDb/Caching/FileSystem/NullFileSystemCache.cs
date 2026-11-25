namespace Fantastic.TheMovieDb.Caching.FileSystem;

using System;
using System.Threading;
using System.Threading.Tasks;

public class NullFileSystemCache : IFileSystemCache
{
    public async Task<T?> TryGet<T>(string cacheKey, Func<Task<T>> refresh, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return await refresh();
    }
}
