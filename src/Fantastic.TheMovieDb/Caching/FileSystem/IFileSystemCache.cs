namespace Fantastic.TheMovieDb.Caching.FileSystem
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IFileSystemCache
    {
        Task<T?> TryGet<T>(string cacheKey, Func<Task<T>> refresh, CancellationToken cancellationToken);
    }
}
