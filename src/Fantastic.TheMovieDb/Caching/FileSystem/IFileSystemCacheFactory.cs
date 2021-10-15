namespace Fantastic.TheMovieDb.Caching.FileSystem
{
    public interface IFileSystemCacheFactory
    {
        IFileSystemCache CreateCache(string name);
    }
}
