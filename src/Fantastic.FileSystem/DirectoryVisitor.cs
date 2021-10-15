namespace Fantastic.FileSystem
{
    using System.Threading.Tasks;
    using System.Threading;
    using System;

    public static class DirectoryVisitor
    {
        public static async Task Visit(this IFileSystem fileSystem, string path, Action<FileItem> callback, CancellationToken cancellationToken = default)
        {
            await VisitInternal(fileSystem, path, 0, callback, cancellationToken);
        }

        public static Task VisitAsync(this IFileSystem fileSystem, string path, Func<FileItem, CancellationToken, Task> callback, CancellationToken cancellationToken = default)
        {
            return VisitAsyncInternal(fileSystem, path, 0, callback, cancellationToken);
        }

        private static async Task VisitAsyncInternal(this IFileSystem fileSystem, string path, int depth, Func<FileItem, CancellationToken, Task> callback, CancellationToken cancellationToken)
        {
            await callback(new FileItem
            {
                Path = path,
                Type = FileItemType.Directory,
                Depth = depth
            }, cancellationToken);

            await foreach (var subDirectory in fileSystem.Directory.EnumerateDirectories(path, cancellationToken))
            {
                await VisitAsyncInternal(fileSystem, subDirectory, depth + 1, callback, cancellationToken);
            }

            await foreach (var file in fileSystem.Directory.EnumerateFiles(path))
            {
                await callback(new FileItem
                {
                    Path = file,
                    Type = FileItemType.File,
                    Depth = depth + 1
                }, cancellationToken);
            }
        }

        private static async Task VisitInternal(IFileSystem fileSystem, string path, int depth, Action<FileItem> callback, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            callback(new FileItem
            {
                Path = path,
                Type = FileItemType.Directory,
                Depth = depth
            });

            await foreach (var subDirectory in fileSystem.Directory.EnumerateDirectories(path))
            {
                await VisitInternal(fileSystem, subDirectory, depth + 1, callback, cancellationToken);
            }

            await foreach (var file in fileSystem.Directory.EnumerateFiles(path))
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                callback(new FileItem
                {
                    Path = file,
                    Type = FileItemType.File,
                    Depth = depth + 1
                });
            }
        }
    }
}
