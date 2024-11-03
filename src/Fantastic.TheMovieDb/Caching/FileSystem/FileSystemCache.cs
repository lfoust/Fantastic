namespace Fantastic.TheMovieDb.Caching.FileSystem
{
    using System;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Fantastic.FileSystem;
    using Fantastic.TheMovieDb.Serialization;

    public class FileSystemCache : IFileSystemCache
    {
        private readonly FileSystemCacheOptions options;
        private readonly IFileSystem fileSystem;
        private string name;

        public FileSystemCache(string name, FileSystemCacheOptions options, IFileSystem fileSystem)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            this.fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _ = EnsureDirectoryCreated();
        }

        private async Task EnsureDirectoryCreated()
        {
            string fullPath = fileSystem.Path.Combine(options.BaseDirectory, name);
            if (!await fileSystem.Directory.Exists(fullPath))
            {
                await fileSystem.Directory.CreateDirectory(fullPath);
            }
        }

        public async Task<T?> TryGet<T>(string cacheKey, Func<Task<T>> refresh, CancellationToken cancellationToken)
        {
            string cachePath = fileSystem.Path.Combine(options.BaseDirectory, name, cacheKey + ".json");
            if (await fileSystem.File.Exists(cachePath))
            {
                var data = await fileSystem.File.ReadAllBytes(cachePath);
                if (data.Length > 0)
                {
                    var item = JsonSerializer.Deserialize<T>(data, SerializationHelper.JsonSerializerOptions);
                    return item;
                }
                else
                {
                    await fileSystem.File.Delete(cachePath);
                }
            }

            T newItem = await refresh();

            if (!Equals(newItem, default(T)))
            {
                // write to cache
                var data = JsonSerializer.SerializeToUtf8Bytes(newItem, SerializationHelper.JsonSerializerOptions);
                await fileSystem.File.WriteAllBytes(cachePath, data, cancellationToken);
            }

            return newItem;
        }
    }
}
