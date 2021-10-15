namespace Fantastic.TheMovieDb.Caching.FileSystem
{
    using System;
    using Fantastic.TheMovieDb.Caching;
    using Microsoft.Extensions.DependencyInjection;

    public static class FileSystemCacheExtensions
    {
        public static void AddFileSystemCache<T>(this IServiceCollection services, Action<FileSystemCacheOptions> config)
        {
            services.AddSingleton<IFileSystemCacheFactory, DefaultFileSystemCacheFactory>();
            var name = TypeNameHelper.GetTypeDisplayName(typeof(T), fullName: false);

            services.AddTransient(s =>
            {
                var options = new FileSystemCacheOptions();
                config(options);
                return options;
            });

            services.AddTransient(s =>
            {
                var factory = s.GetRequiredService<IFileSystemCacheFactory>();
                var cache = factory.CreateCache(name);

                return cache;
            });
        }
    }
}
