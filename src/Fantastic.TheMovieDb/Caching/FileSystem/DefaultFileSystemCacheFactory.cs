namespace Fantastic.TheMovieDb.Caching.FileSystem
{
    using System;
    using Fantastic.FileSystem;

    public class DefaultFileSystemCacheFactory : IFileSystemCacheFactory
    {
        private IFileSystem fileSystem;
        private readonly FileSystemCacheOptions options;

        public DefaultFileSystemCacheFactory(IFileSystem fileSystem, FileSystemCacheOptions options)
        {
            this.fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public IFileSystemCache CreateCache(string name)
        {
            return new FileSystemCache(name, options, fileSystem);
        }
    }
}
